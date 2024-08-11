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
using OrganicShop.Domain.Dtos.ProductItemDtos;
using OrganicShop.Domain.Dtos.OrderDtos;
using OrganicShop.BLL.Extensions;
using System.Collections.Generic;
using OrganicShop.Domain.Validation.CouponValidators;
using Microsoft.AspNetCore.Http.HttpResults;
using OrganicShop.Domain.Dtos.CouponDtos;

namespace OrganicShop.BLL.Services
{
    public class CartService : Service<Cart>, ICartService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly ICartRepository _CartRepository;
        private readonly IProductRepository _ProductRepository;
        private readonly ICouponRepository _CouponRepository;
        private readonly IProductItemRepository _ProductItemRepository;
        private readonly IValidator<CreateCartDto> _ValidatorCreateCart;
        private readonly IValidator<UpdateCartDto> _ValidatorUpdateCart;
        private readonly IValidator<CouponApplyingDto> _ValidatorCouponApplying;

        public CartService(IApplicationUserProvider provider, IMapper mapper, ICartRepository CartRepository,
            IValidator<UpdateCartDto> validatorUpdateCart, IValidator<CreateCartDto> validatorCreateCart,
            IProductItemRepository productItemRepository, ICouponRepository couponRepository, IProductRepository productRepository,
            IValidator<CouponApplyingDto> validatorCouponApplying) : base(provider)
        {
            _Mapper = mapper;
            _CartRepository = CartRepository;
            _ValidatorUpdateCart = validatorUpdateCart;
            _ValidatorCreateCart = validatorCreateCart;
            _ProductItemRepository = productItemRepository;
            _CouponRepository = couponRepository;
            _ProductRepository = productRepository;
            _ValidatorCouponApplying = validatorCouponApplying;
        }

        #endregion



        public async Task<ServiceResponse<PageDto<Cart, CartListDto, long>>> GetAll(FilterCartDto? filter = null, PagingDto? paging = null)
        {
            var query = _CartRepository.GetQueryable();

            if (filter == null) filter = new FilterCartDto();

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
            return new ServiceResponse<PageDto<Cart, CartListDto, long>>(ResponseResult.Success, pageDto);
        }


        public async Task<ServiceResponse<CartDetailDto>> GetDetail(long UserId)
        {
            if (UserId < 1)
                return new ServiceResponse<CartDetailDto>(ResponseResult.NotFound, null);

            var cart = await _CartRepository.GetQueryable()
                .Include(a => a.ProductItems)
                    .ThenInclude(a => a.Product)
                        .ThenInclude(a => a.Pictures)
                .Include(a => a.ProductItems)
                    .ThenInclude(a => a.Product)
                        .ThenInclude(a => a.DiscountProducts)
                            .ThenInclude(a => a.Discount)
                 .FirstOrDefaultAsync(a => a.UserId == UserId);

            if (cart == null)
                return new ServiceResponse<CartDetailDto>(ResponseResult.NotFound, null);

            return new ServiceResponse<CartDetailDto>(ResponseResult.Success, _Mapper.Map<CartDetailDto>(cart));
        }


        public async Task<ServiceResponse<CartDetailDto>> GetDetail(long UserId, string couponCode)
        {
            if (UserId < 1)
                return new ServiceResponse<CartDetailDto>(ResponseResult.NotFound, null);

            Coupon? coupon = null;

            if (string.IsNullOrEmpty(couponCode) == false)
            {
                coupon = await _CouponRepository.GetQueryable()
                    .Include(a => a.CouponCategories)
                    .FirstOrDefaultAsync(a => a.Code == couponCode);

            }

            Cart? cart = null;

            #region getting card

            var query = _CartRepository.GetQueryable();
            query = query
                .Include(a => a.ProductItems)
                    .ThenInclude(a => a.Product)
                        .ThenInclude(a => a.Pictures)
                .Include(a => a.ProductItems)
                    .ThenInclude(a => a.Product)
                        .ThenInclude(a => a.DiscountProducts)
                            .ThenInclude(a => a.Discount)
                            .AsQueryable();

            if (coupon != null)
            {
                query = query
                      .Include(a => a.ProductItems)
                        .ThenInclude(a => a.Product)
                            .ThenInclude(a => a.Categories)
                      .AsQueryable();
            }

            cart = await query
               .FirstOrDefaultAsync(a => a.UserId == UserId);

            #endregion

            if (cart == null)
                return new ServiceResponse<CartDetailDto>(ResponseResult.NotFound, null);

            var cartDetailDto = _Mapper.Map<CartDetailDto>(cart);
            var products = cart.ProductItems
                .Select(a => a.Product)
                .ToList();

            if (coupon != null)
                if (coupon.IsValid(cartDetailDto.Bill.TotalPrice) && coupon.IsAcceptableForProducts(products))
                    cartDetailDto.Bill = CartMappers.ToBillDto(cart.ProductItems.ToArray(), coupon);

            return new ServiceResponse<CartDetailDto>(ResponseResult.Success, cartDetailDto);
        }


        public async Task<ServiceResponse<CartDetailDto>> GetDetail(List<ProductItemCookieDto> productItemCookieDtos, string? couponCode = null)
        {
            Coupon? coupon = null;
            if (string.IsNullOrWhiteSpace(couponCode) == false)
            {
                coupon = await _CouponRepository.GetQueryable()
                    .Include(a => a.CouponCategories)
                    .FirstOrDefaultAsync(a => a.Code == couponCode);
            }

            #region getting productItems

            var productIds = productItemCookieDtos.Select(a => a.ProductId);

            var query = _ProductRepository.GetQueryable()
                   .Include(a => a.Pictures)
                   .Include(a => a.DiscountProducts)
                       .ThenInclude(a => a.Discount)
                   .AsQueryable();
            if (coupon != null)
            {
                query = query
                    .Include(a => a.Categories)
                    .AsQueryable();
            }
            var products = await query
                .Where(a => productIds.Contains(a.Id))
                .ToListAsync();

            List<ProductItemListDto> productItemListDtos = productItemCookieDtos.ToListDtos(products);

            #endregion

            CartDetailDto cartDetailDto = CartMappers.ToDetailDto(productItemListDtos, coupon);

            if (coupon != null)
                if (coupon.IsValid(cartDetailDto.Bill.TotalPrice) && coupon.IsAcceptableForProducts(products))
                    cartDetailDto.Bill = CartMappers.ToBillDto(productItemListDtos, coupon);

            return new ServiceResponse<CartDetailDto>(ResponseResult.Success, cartDetailDto);
        }



        public async Task<ServiceResponse<Empty>> Create(CreateCartDto create)
        {
            var validationResult = await _ValidatorCreateCart.ValidateAsync(create);
            if (!validationResult.IsValid)
                return new ServiceResponse<Empty>(create, validationResult);

            if (await _CartRepository.GetQueryable().Where(a => a.UserId == create.UserId).CountAsync() > 2)
                return new ServiceResponse<Empty>(ResponseResult.Failed, _Message.MaxCreate(2));

            Cart Cart = _Mapper.Map<Cart>(create);

            await _CartRepository.Add(Cart, _AppUserProvider.User.Id);
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


        public async Task<ServiceResponse<CartDetailDto>> ApplyCoupon(CouponApplyingDto couponApplying)
        {
            if (string.IsNullOrWhiteSpace(couponApplying.Code))
                return new ServiceResponse<CartDetailDto>(ResponseResult.NotFound, "کد تخفیف نادرست است");

            Coupon? coupon = await _CouponRepository.GetQueryable()
                .Include(a => a.CouponCategories)
                .FirstOrDefaultAsync(a => a.Code == couponApplying.Code);

            if (coupon == null)
                return new ServiceResponse<CartDetailDto>(ResponseResult.NotFound, "کد تخفیف نادرست است");

            var couponValidationresult = await _ValidatorCouponApplying.ValidateAsync(coupon.ToApplyDto(null, null));
            if (couponValidationresult.IsValid == false)
                return new ServiceResponse<CartDetailDto>(nameof(couponApplying.Code), couponValidationresult);

            #region grtting products

            var productItems = await _ProductItemRepository.GetQueryable()
                .Include(a => a.Product)
                    .ThenInclude(a => a.Categories)
                .Include(a => a.Product)
                    .ThenInclude(a => a.DiscountProducts)
                        .ThenInclude(a => a.Discount)
               .Include(a => a.Cart)
               .Where(a => a.Cart.UserId == couponApplying.UserId)
               .ToListAsync();

            var products = productItems.Select(a => a.Product).ToArray();

            #endregion

            var cartDetailDto = new CartDetailDto
            {
                Id = productItems.First().CartId.Value,
                ProductItems = new ProductItemListDto[0],
                Bill = CartMappers.ToBillDto(productItems.ToArray(), null),
            };

            couponValidationresult = await _ValidatorCouponApplying.ValidateAsync(coupon.ToApplyDto(cartDetailDto.Bill.TotalPrice, products.ToArray()));
            if (couponValidationresult.IsValid == false)
                return new ServiceResponse<CartDetailDto>(nameof(couponApplying.Code), couponValidationresult);

            cartDetailDto.Bill = CartMappers.ToBillDto(productItems.ToArray(), coupon);

            return new ServiceResponse<CartDetailDto>(ResponseResult.Success, cartDetailDto);
        }



        public async Task<ServiceResponse<CartDetailDto>> ApplyCoupon(List<ProductItemCookieDto> productItemCookieDtos, CouponApplyingDto couponApplying)
        {
            if (string.IsNullOrWhiteSpace(couponApplying.Code))
                return new ServiceResponse<CartDetailDto>(ResponseResult.NotFound, "کد تخفیف نادرست است");

            Coupon? coupon = await _CouponRepository.GetQueryable()
                .Include(a => a.CouponCategories)
                .FirstOrDefaultAsync(a => a.Code == couponApplying.Code);

            if (coupon == null)
                return new ServiceResponse<CartDetailDto>(ResponseResult.Failed, "کد تخفیف نادرست است");

            var couponValidationresult = await _ValidatorCouponApplying.ValidateAsync(coupon.ToApplyDto(null, null));
            if (couponValidationresult.IsValid == false)
                return new ServiceResponse<CartDetailDto>(nameof(couponApplying.Code), couponValidationresult);

            #region getting productItems

            var productIds = productItemCookieDtos.Select(a => a.ProductId);

            var products = await _ProductRepository.GetQueryable()
                   .Include(a => a.Pictures)
                   .Include(a => a.Categories)
                   .Include(a => a.DiscountProducts)
                       .ThenInclude(a => a.Discount)
               .Where(a => productIds.Contains(a.Id))
               .ToListAsync();

            List<ProductItemListDto> productItemListDtos = new List<ProductItemListDto>();

            Product? product = null;
            foreach (var productItemCookieDto in productItemCookieDtos)
            {
                product = products.First(a => a.Id == productItemCookieDto.ProductId);
                productItemListDtos.Add(productItemCookieDto.ToListDto(product));
            }

            #endregion

            var cartDetailDto = new CartDetailDto
            {
                Id = 0,
                ProductItems = productItemListDtos.ToArray(),
                Bill = CartMappers.ToBillDto(productItemListDtos , null),
            };
           
            couponValidationresult = await _ValidatorCouponApplying.ValidateAsync(coupon.ToApplyDto(cartDetailDto.Bill.TotalPrice, products.ToArray()));
            if (couponValidationresult.IsValid == false)
                return new ServiceResponse<CartDetailDto>(nameof(couponApplying.Code), couponValidationresult);

            cartDetailDto.Bill = CartMappers.ToBillDto(productItemListDtos, coupon);

            return new ServiceResponse<CartDetailDto>(ResponseResult.Success, cartDetailDto);
        }


        public async Task<ServiceResponse<BillDto>> GetBill(long userId, string? couponCode = null)
        {
            Coupon? coupon = null;

            if (string.IsNullOrWhiteSpace(couponCode) == false)
                coupon = await _CouponRepository.GetQueryable()
                    .FirstOrDefaultAsync(a => a.Code == couponCode);

            #region includes

            var query = _ProductItemRepository.GetQueryable()
                .Include(a => a.Cart)
                .Include(a => a.Product)
                    .ThenInclude(a => a.DiscountProducts)
                        .ThenInclude(a => a.Discount)
                        .AsQueryable();

            if (coupon != null)
            {
                query = query
                    .Include(a => a.Product)
                        .ThenInclude(a => a.Categories)
                        .AsQueryable();
            }

            #endregion

            var productItems = await query.Where(a => a.Cart.UserId == userId).ToArrayAsync();

            var billDto = CartMappers.ToBillDto(productItems, coupon);

            if (coupon != null)
                if (coupon.IsValid(billDto.TotalPrice) && coupon.IsAcceptableForProducts(productItems.Select(a => a.Product).ToList()))
                {
                    billDto.CouponId = coupon.Id;
                    billDto.CouponCode = couponCode;
                    billDto.CouponAmount = coupon.GetAmount(billDto.TotalPrice);
                }

            return new ServiceResponse<BillDto>(ResponseResult.Success, billDto);
        }


        public async Task<ServiceResponse<BillDto>> GetBill(List<ProductItemCookieDto> productItemCookieDtos, string? couponCode = null)
        {
            Coupon? coupon = null;

            if (string.IsNullOrWhiteSpace(couponCode) == false)
                coupon = await _CouponRepository.GetQueryable()
                    .FirstOrDefaultAsync(a => a.Code == couponCode);

            #region getting productItems

            var productIds = productItemCookieDtos.Select(a => a.ProductId);

            var query = _ProductRepository.GetQueryable()
                   .Include(a => a.DiscountProducts)
                       .ThenInclude(a => a.Discount)
                   .AsQueryable();
            if (coupon != null)
            {
                query = query
                    .Include(a => a.Categories)
                    .AsQueryable();
            }
            var products = await query
                .Where(a => productIds.Contains(a.Id))
                .ToListAsync();

            List<ProductItemListDto> productItemListDtos = productItemCookieDtos.ToListDtos(products);

            #endregion

            BillDto billDto = CartMappers.ToBillDto(productItemListDtos, null);

            if (coupon != null)
                if (coupon.IsValid(billDto.TotalPrice) && coupon.IsAcceptableForProducts(products))
                {
                    billDto = CartMappers.ToBillDto(productItemListDtos, coupon);
                }

            return new ServiceResponse<BillDto>(ResponseResult.Success, billDto);
        }









    }
}
