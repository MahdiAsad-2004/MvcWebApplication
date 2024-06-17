using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.DAL.Repositories;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Response;
using OrganicShop.Domain.Dtos.CartDtos;
using AutoMapper;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.IProviders;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Enums.Response;
using FluentValidation;

namespace OrganicShop.BLL.Services
{
    public class CartService : Service<Cart> , ICartService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly ICartRepository _CartRepository;
        private readonly IValidator<CreateCartDto> _ValidatorCreateCart;
        private readonly IValidator<UpdateCartDto> _ValidatorUpdateCart;

        public CartService(IApplicationUserProvider provider, IMapper mapper, ICartRepository CartRepository,
            IValidator<UpdateCartDto> validatorUpdateCart, IValidator<CreateCartDto> validatorCreateCart) : base(provider)
        {
            _Mapper = mapper;
            _CartRepository = CartRepository;
            _ValidatorUpdateCart = validatorUpdateCart;
            _ValidatorCreateCart = validatorCreateCart;
        }

        #endregion



        public async Task<ServiceResponse<PageDto<Cart, CartListDto, long>>> GetAll(FilterCartDto? filter = null, PagingDto? paging = null)
        {
            var query = _CartRepository.GetQueryable();

            if (filter == null) filter = new FilterCartDto();
            if (paging == null) paging = new PagingDto();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.UserId > 0)
                query = query.Where(q => q.UserId == filter.UserId);

            #endregion

            #region sort

            query = filter.ApplySortType(query);

            #endregion

            PageDto<Cart, CartListDto, long> pageDto = new();
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => _Mapper.Map<CartListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);
            return new ServiceResponse<PageDto<Cart, CartListDto, long>>(ResponseResult.Success,pageDto);
        }


        public async Task<ServiceResponse<CartDetailDto>> GetDetail(long Id)
        {
            if (Id < 1)
                return new ServiceResponse<CartDetailDto>(ResponseResult.NotFound, null);

            var cart = await _CartRepository.GetQueryable()
                .Include(a => a.ProductItems)
                .FirstOrDefaultAsync(a => a.Id == Id);

            if(cart == null)
                return new ServiceResponse<CartDetailDto>(ResponseResult.NotFound, null);

            return new ServiceResponse<CartDetailDto>(ResponseResult.Success, _Mapper.Map<CartDetailDto>(cart));
        }



        public async Task<ServiceResponse<Empty>> Create(CreateCartDto create)
        {
            var validationResult = await _ValidatorCreateCart.ValidateAsync(create);
            if (!validationResult.IsValid)
                return new ServiceResponse<Empty>(create , validationResult);

            if (await _CartRepository.GetQueryable().Where(a => a.UserId == create.UserId).CountAsync() > 2)
                return new ServiceResponse<Empty>(ResponseResult.Failed, _Message.MaxCreate(2));

            Cart Cart = _Mapper.Map<Cart>(create);

            await _CartRepository.Add(Cart,_AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse<Empty>> Update(UpdateCartDto update)
        {
            var validationResult = await _ValidatorUpdateCart.ValidateAsync(update);
            if (!validationResult.IsValid)
                return new ServiceResponse<Empty>(update, validationResult);

            Cart? Cart = await _CartRepository.GetAsTracking(update.Id);
            
            if (Cart == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _CartRepository.Update(_Mapper.Map<Cart>(update), _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse<Empty>> Delete(long delete)
        {
            Cart? Cart = await _CartRepository.GetAsTracking(delete);

            if (Cart == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _CartRepository.SoftDelete(Cart, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessDelete());
        }




    }
}
