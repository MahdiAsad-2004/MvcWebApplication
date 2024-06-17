using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.SellerDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.Response;
using AutoMapper;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.IProviders;
using OrganicShop.Domain.Enums;
using OrganicShop.DAL.Repositories;
using OrganicShop.Domain.Dtos.Combo;
using OrganicShop.BLL.Extensions;
using FluentValidation;

namespace OrganicShop.BLL.Services
{
    public class SellerService : Service<Seller>, ISellerService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly ISellerRepository _SellerRepository;
        private readonly IValidator<CreateSellerDto> _ValidatorCreateSeller;
        private readonly IValidator<UpdateSellerDto> _ValidatorUpdateSeller;

        public SellerService(IApplicationUserProvider provider, IMapper mapper, ISellerRepository SellerRepository,
            IValidator<CreateSellerDto> validatorCreateSeller, IValidator<UpdateSellerDto> validatorUpdateSeller) : base(provider)
        {
            _Mapper = mapper;
            _SellerRepository = SellerRepository;
            _ValidatorCreateSeller = validatorCreateSeller;
            _ValidatorUpdateSeller = validatorUpdateSeller;
        }

        #endregion


        public async Task<ServiceResponse<PageDto<Seller, SellerListDto, int>>> GetAll(FilterSellerDto? filter = null,PagingDto? paging = null)
        {
            var query = _SellerRepository.GetQueryable();

            if (filter == null) filter = new FilterSellerDto();
            if (paging == null) paging = new PagingDto();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.Title != null)
                query = query.Where(q => EF.Functions.Like(q.Title, $"%{filter.Title}%"));

            if (filter.UserId != null)
                query = query.Where(q => q.UserId == filter.UserId);

            #endregion

            #region sort

            query = filter.ApplySortType(query);

            #endregion

            PageDto<Seller, SellerListDto,int> pageDto = new();
            pageDto.List = pageDto.SetPaging(query , paging).Select(a => _Mapper.Map<SellerListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return new ServiceResponse<PageDto<Seller, SellerListDto, int>>(ResponseResult.Success,pageDto);
        }



        public async Task<ServiceResponse<PageDto<Seller,SellerSummaryDto,int>>> GetAllSummary(FilterSellerDto? filter = null, PagingDto? paging = null)
        {
            var query = _SellerRepository.GetQueryable();

            #region includes

            query = query
                .Include(a => a.Picture)
                .Include(a => a.Address)
                .Include(a => a.Products)
                .Include(a => a.Comments)
                .AsQueryable()
                .Select(a => a.ToModel());

            #endregion

            if (filter == null) filter = new FilterSellerDto();
            if (paging == null) paging = new PagingDto();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.Title != null)
                query = query.Where(q => EF.Functions.Like(q.Title, $"%{filter.Title}%"));

            if (filter.UserId != null)
                query = query.Where(q => q.UserId == filter.UserId);

            #endregion

            #region sort

            query = filter.ApplySortType(query);

            #endregion

            PageDto<Seller, SellerSummaryDto, int> pageDto = new();
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => _Mapper.Map<SellerSummaryDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return new ServiceResponse<PageDto<Seller,SellerSummaryDto,int>>(ResponseResult.Success, pageDto);
        }



        public async Task<ServiceResponse<SellerDetailDto>> GetDetail(string codedTitle)
        {
            string title = TextExtensions.DecodePersianString(codedTitle);
            
            if(string.IsNullOrWhiteSpace(title))
                return new ServiceResponse<SellerDetailDto>(ResponseResult.NotFound,null);

            var query = _SellerRepository.GetQueryable();

            #region includes

            query = query
                .Include(a => a.Picture)
                .Include(a => a.Address)
                .Include(a => a.Products)
                .Include(a => a.Comments)
                    .ThenInclude(a => a.User)
                .AsQueryable();

            #endregion

            var Seller = await query.FirstOrDefaultAsync(a => a.Title == title);
            
            if(Seller == null)
                return new ServiceResponse<SellerDetailDto>(ResponseResult.NotFound,null);

            return new ServiceResponse<SellerDetailDto>(ResponseResult.Success, _Mapper.Map<SellerDetailDto>(Seller));
        }


        public async Task<ServiceResponse<Empty>> Create(CreateSellerDto create)
        {
            var validationResult = await _ValidatorCreateSeller.ValidateAsync(create);
            if (!validationResult.IsValid)
                return new ServiceResponse<Empty>(create, validationResult);

            Seller Seller = _Mapper.Map<Seller>(create);

            if (await _SellerRepository.GetQueryable().AnyAsync(a => EF.Functions.Like(a.Title , create.Title)))
                return new ServiceResponse<Empty>(ResponseResult.Failed, _Message.EntityExist(create,a => nameof(a.Title)));

            await _SellerRepository.Add(Seller,_AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse<Empty>> Update(UpdateSellerDto update)
        {
            var validationResult = await _ValidatorUpdateSeller.ValidateAsync(update);
            if (!validationResult.IsValid)
                return new ServiceResponse<Empty>(update, validationResult);

            Seller? Seller = await _SellerRepository.GetAsTracking(update.Id);
            
            if (Seller == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            if (await _SellerRepository.GetQueryable().AnyAsync(a => EF.Functions.Like(a.Title , update.Title) && a.Id != update.Id))
                return new ServiceResponse<Empty>(ResponseResult.Failed, _Message.EntityExist(update, a => nameof(a.Title)));

            await _SellerRepository.Update(_Mapper.Map(update,Seller), _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse<Empty>> Delete(int delete)
        {
            Seller? Seller = await _SellerRepository.GetAsTracking(delete);

            if (Seller == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _SellerRepository.SoftDelete(Seller, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessDelete());
        }

    }
}
