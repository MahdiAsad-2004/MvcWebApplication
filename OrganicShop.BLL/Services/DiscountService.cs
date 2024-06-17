using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.DiscountDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Entities.Relations;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.Response;
using AutoMapper;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.IProviders;
using OrganicShop.Domain.Enums;
using OrganicShop.BLL.Extensions;
using FluentValidation;

namespace OrganicShop.BLL.Services
{
    public class DiscountService : Service<Discount>, IDiscountService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly IDiscountRepository _DiscountRepository;
        private readonly IProductRepository _ProductRepository;
        private readonly IDiscountProductsRepository _DiscountProductsRepository;
        private readonly IValidator<CreateDiscountDto> _ValidatorCreateDiscount;
        private readonly IValidator<UpdateDiscountDto> _ValidatorUpdateDiscount;

        public DiscountService(IApplicationUserProvider provider, IMapper mapper, IDiscountRepository discountRepository,
            IDiscountProductsRepository discountProductsRepository, IProductRepository productRepository,
            IValidator<CreateDiscountDto> validatorCreateDiscount, IValidator<UpdateDiscountDto> validatorUpdateDiscount) : base(provider)
        {
            _Mapper = mapper;
            _DiscountRepository = discountRepository;
            _DiscountProductsRepository = discountProductsRepository;
            _ProductRepository = productRepository;
            _ValidatorCreateDiscount = validatorCreateDiscount;
            _ValidatorUpdateDiscount = validatorUpdateDiscount;
        }

        #endregion


        public async Task<ServiceResponse<PageDto<Discount, DiscountListDto, int>>> GetAll(FilterDiscountDto? filter = null, PagingDto? paging = null)
        {
            var query = _DiscountRepository.GetQueryable()
                .AsQueryable();

            if (filter == null) filter = new FilterDiscountDto();
            if (paging == null) paging = new PagingDto();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.ProductId > 0)
            {
                IQueryable<Discount> query2 = _DiscountProductsRepository.GetQueryable()
                    .Where(a => a.ProductId == filter.ProductId)
                    .Select(a => a.Discount)
                    .AsQueryable();
                query = query.IntersectBy(query2.Select(a => a.Id), a => a.Id);
            }

            if (filter.IsFixDiscount != null)
            {
                if (filter.IsFixDiscount == true)
                    query = query.Where(a => a.Price != null && a.Percent == null);
                else
                    query = query.Where(a => a.Price == null && a.Percent != null);
            }

            #endregion

            #region sort

            query = filter.ApplySortType(query);

            #endregion

            PageDto<Discount, DiscountListDto, int> pageDto = new();
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => _Mapper.Map<DiscountListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return new ServiceResponse<PageDto<Discount, DiscountListDto, int>>(ResponseResult.Success, pageDto);
        }


        public async Task<ServiceResponse<UpdateDiscountDto>> Get(int Id)
        {
            if (Id < 1)
                return new ServiceResponse<UpdateDiscountDto>(ResponseResult.NotFound, null);

            var discount = await _DiscountRepository.GetQueryable()
                .AsNoTracking()
                .Include(a => a.DiscountProducts)
                .FirstOrDefaultAsync(a => a.Equals(Id));

            if (discount != null)
                return new ServiceResponse<UpdateDiscountDto>(ResponseResult.Success, _Mapper.Map<UpdateDiscountDto>(discount));

            return new ServiceResponse<UpdateDiscountDto>(ResponseResult.NotFound, null);
        }




        public async Task<ServiceResponse<Empty>> Create(CreateDiscountDto create)
        {
            var validationResult = await _ValidatorCreateDiscount.ValidateAsync(create);
            if (!validationResult.IsValid)
                return new ServiceResponse<Empty>(create, validationResult);

            Discount Discount = _Mapper.Map<Discount>(create);

            #region Discount Products

            foreach (var id in create.ProductIds)
            {
                Discount.DiscountProducts.Add(new DiscountProducts
                {
                    ProductId = id,
                    BaseEntity = new BaseEntity(true),
                });
            }

            #endregion

            await _DiscountRepository.Add(Discount, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse<Empty>> Update(UpdateDiscountDto update)
        {
            var validationResult = await _ValidatorUpdateDiscount.ValidateAsync(update);
            if (!validationResult.IsValid)
                return new ServiceResponse<Empty>(update, validationResult);

            Discount? Discount = await _DiscountRepository.GetQueryable()
                .Include(a => a.DiscountProducts)
                .AsTracking()
                .FirstOrDefaultAsync(a => a.Id == update.Id);

            if (Discount == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            #region Discount Products

            foreach (var discountProduct in Discount.DiscountProducts.ExceptBy(update.ProductIds, a => a.ProductId))
            {
                Discount.DiscountProducts.Remove(discountProduct);
            }

            foreach (var id in update.ProductIds.ExceptBy(Discount.DiscountProducts.Select(a => a.ProductId), a => a))
            {
                Discount.DiscountProducts.Add(new DiscountProducts
                {
                    DiscountId = update.Id,
                    ProductId = id,
                    BaseEntity = new BaseEntity(true),
                });
            }

            #endregion

            await _DiscountRepository.Update(_Mapper.Map<Discount>(update), _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse<Empty>> Delete(int id)
        {

            Discount? Discount = await _DiscountRepository.GetAsTracking(id);

            if (Discount == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _DiscountRepository.SoftDelete(Discount, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessDelete());
        }
    }
}
