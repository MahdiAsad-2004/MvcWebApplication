using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.CouponDtos;
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
    public class CouponService : Service<Coupon>, ICouponService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly ICouponRepository _CouponRepository;
        private readonly IProductRepository _ProductRepository;
        private readonly IValidator<CreateCouponDto> _ValidatorCreateCoupon;
        private readonly IValidator<UpdateCouponDto> _ValidatorUpdateCoupon;

        public CouponService(IApplicationUserProvider provider, IMapper mapper, ICouponRepository CouponRepository,IProductRepository productRepository,
            IValidator<CreateCouponDto> validatorCreateCoupon, IValidator<UpdateCouponDto> validatorUpdateCoupon) : base(provider)
        {
            _Mapper = mapper;
            _CouponRepository = CouponRepository;
            _ProductRepository = productRepository;
            _ValidatorCreateCoupon = validatorCreateCoupon;
            _ValidatorUpdateCoupon = validatorUpdateCoupon;
        }

        #endregion


        public async Task<ServiceResponse<PageDto<Coupon, CouponListDto, int>>> GetAll(FilterCouponDto? filter = null, PagingDto? paging = null)
        {
            var query = _CouponRepository.GetQueryable()
                .AsQueryable();

            if (filter == null) filter = new FilterCouponDto();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.IsFixCoupon != null)
            {
                if (filter.IsFixCoupon == true)
                    query = query.Where(a => a.Price != null && a.Percent == null);
                else
                    query = query.Where(a => a.Price == null && a.Percent != null);
            }

            #endregion

            #region sort

            query = filter.ApplySortType(query);

            #endregion

            PageDto<Coupon, CouponListDto, int> pageDto = new();
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => _Mapper.Map<CouponListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return new ServiceResponse<PageDto<Coupon, CouponListDto, int>>(ResponseResult.Success, pageDto);
        }


        public async Task<ServiceResponse<UpdateCouponDto>> Get(int Id)
        {
            if (Id < 1)
                return new ServiceResponse<UpdateCouponDto>(ResponseResult.NotFound, null);

            var Coupon = await _CouponRepository.GetQueryable()
                .AsNoTracking()
                .Include(a => a.CouponCategories)
                .FirstOrDefaultAsync(a => a.Equals(Id));

            if (Coupon != null)
                return new ServiceResponse<UpdateCouponDto>(ResponseResult.Success, _Mapper.Map<UpdateCouponDto>(Coupon));

            return new ServiceResponse<UpdateCouponDto>(ResponseResult.NotFound, null);
        }




        public async Task<ServiceResponse<Empty>> Create(CreateCouponDto create)
        {
            var validationResult = await _ValidatorCreateCoupon.ValidateAsync(create);
            if (!validationResult.IsValid)
                return new ServiceResponse<Empty>(create, validationResult);

            Coupon Coupon = _Mapper.Map<Coupon>(create);

            await _CouponRepository.Add(Coupon, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse<Empty>> Update(UpdateCouponDto update)
        {
            var validationResult = await _ValidatorUpdateCoupon.ValidateAsync(update);
            if (!validationResult.IsValid)
                return new ServiceResponse<Empty>(update, validationResult);

            Coupon? Coupon = await _CouponRepository.GetQueryable()
                .Include(a => a.CouponCategories)
                .AsTracking()
                .FirstOrDefaultAsync(a => a.Id == update.Id);

            if (Coupon == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            #region Coupon Products

            //foreach (var CouponProduct in Coupon.CouponProducts.ExceptBy(update.ProductIds, a => a.ProductId))
            //{
            //    Coupon.CouponProducts.Remove(CouponProduct);
            //}

            //foreach (var id in update.ProductIds.ExceptBy(Coupon.CouponProducts.Select(a => a.ProductId), a => a))
            //{
            //    Coupon.CouponProducts.Add(new CouponProducts
            //    {
            //        CouponId = update.Id,
            //        ProductId = id,
            //        BaseEntity = new BaseEntity(true),
            //    });
            //}

            #endregion

            await _CouponRepository.Update(_Mapper.Map<Coupon>(update), _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse<Empty>> Delete(int id)
        {

            Coupon? Coupon = await _CouponRepository.GetAsTracking(id);

            if (Coupon == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _CouponRepository.SoftDelete(Coupon, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessDelete());
        }
    
    






    }
}
