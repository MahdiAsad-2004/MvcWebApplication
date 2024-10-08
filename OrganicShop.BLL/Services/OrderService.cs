﻿using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.OrderDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.TrackingStatusDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.Response;
using AutoMapper;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.IProviders;
using OrganicShop.Domain.Enums;
using System.Text;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Entities.Base;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace OrganicShop.BLL.Services
{
    public class OrderService : Service<Order>, IOrderService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly IOrderRepository _OrderRepository;
        private readonly IAddressRepository _AddressRepository;
        private readonly IProductItemRepository _ProductItemRepository;
        private readonly INextCartRepository _NextCartRepository;
        private readonly ICartRepository _CartRepository;
        private readonly IDiscountRepository _DiscountRepository;
        private readonly ICouponRepository _CouponRepository;
        private readonly IValidator<CreateOrderDto> _ValidatorCreateOrder;
        private readonly IValidator<UpdateOrderDto> _ValidatorUpdateOrder;

        public OrderService(IApplicationUserProvider provider, IMapper mapper, IOrderRepository OrderRepository, IAddressRepository AddressRepository,
            IProductItemRepository ProductItemRepository, INextCartRepository nextCartRepository, IValidator<CreateOrderDto> validatorCreateOrder,
            IValidator<UpdateOrderDto> validatorUpdateOrder, ICartRepository cartRepository, IDiscountRepository discountRepository, ICouponRepository couponRepository) : base(provider)
        {
            _Mapper = mapper;
            _OrderRepository = OrderRepository;
            _AddressRepository = AddressRepository;
            _ProductItemRepository = ProductItemRepository;
            _NextCartRepository = nextCartRepository;
            _ValidatorCreateOrder = validatorCreateOrder;
            _ValidatorUpdateOrder = validatorUpdateOrder;
            _CartRepository = cartRepository;
            _DiscountRepository = discountRepository;
            _CouponRepository = couponRepository;
        }

        #endregion


        public async Task<ServiceResponse<PageDto<Order, OrderListDto, long>>> GetAll(FilterOrderDto? filter = null, PagingDto? paging = null)
        {
            var query = _OrderRepository.GetQueryable()
                .Include(a => a.Receiver)
                .AsQueryable();

            if (filter == null) filter = new FilterOrderDto();

            #region flters

            query = filter.ApplyBaseFilters(query);

            if (filter.UserId > 0)
                query = query.Where(a => a.UserId == filter.UserId);

            if (string.IsNullOrWhiteSpace(filter.UserPhoneNumber))
                query = query.Where(a => EF.Functions.Like(a.Receiver.PhoneNumber, $"%{filter.UserPhoneNumber}%"));

            if (string.IsNullOrWhiteSpace(filter.TrackingCode))
                query = query.Where(a => EF.Functions.Like(a.TrackingCode, $"%{filter.TrackingCode}%"));

            if (filter.OrderStatus != null)
                query = query.Where(a => a.OrderStatus == filter.OrderStatus);

            if (string.IsNullOrWhiteSpace(filter.ShippingMethodName) == false)
                query = query.Where(a => EF.Functions.Like(a.ShippingMethodName, $"%{filter.ShippingMethodName}%"));

            #endregion

            #region sort

            query = filter.ApplySortType(query);

            #endregion

            PageDto<Order, OrderListDto, long> pageDto = new();
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => _Mapper.Map<OrderListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return new ServiceResponse<PageDto<Order, OrderListDto, long>>(ResponseResult.Success, pageDto);
        }



        public async Task<ServiceResponse<OrderDetailDto>> GetDetail(string trackingCode)
        {
            if (string.IsNullOrEmpty(trackingCode))
                return new ServiceResponse<OrderDetailDto>(ResponseResult.NotFound, null);

            var query = _OrderRepository.GetQueryable();

            #region includes

            query = query
                .Include(a => a.ProductItems)
                    .ThenInclude(a => a.Product)
                        .ThenInclude(a => a.Pictures)
                .Include(a => a.ProductItems)
                    .ThenInclude(a => a.Product)
                .AsQueryable();

            #endregion

            var order = await query.FirstOrDefaultAsync(a => a.TrackingCode == trackingCode);

            if (order == null)
                return new ServiceResponse<OrderDetailDto>(ResponseResult.NotFound, null);

            return new ServiceResponse<OrderDetailDto>(ResponseResult.Success, _Mapper.Map<OrderDetailDto>(order));
        }



        public async Task<ServiceResponse<OrderTrackDto>> GetTracking(string trackingCode)
        {
            if (string.IsNullOrEmpty(trackingCode))
                return new ServiceResponse<OrderTrackDto>(ResponseResult.NotFound, null);

            var query = _OrderRepository.GetQueryable();

            #region includes

            query = query
                .Include(a => a.TrackingDescriptions)
                .Include(a => a.TrackingStatuses)
                .Include(a => a.Receiver)
                    .ThenInclude(a => a.Picture)
                .AsQueryable();

            #endregion

            var order = await query.FirstOrDefaultAsync(a => a.TrackingCode == trackingCode);

            if (order == null)
                return new ServiceResponse<OrderTrackDto>(ResponseResult.NotFound, null);

            return new ServiceResponse<OrderTrackDto>(ResponseResult.Success, _Mapper.Map<OrderTrackDto>(order));
        }







        public async Task<ServiceResponse<string>> Create(CreateOrderDto create)
        {
            var validationResult = await _ValidatorCreateOrder.ValidateAsync(create);
            if (!validationResult.IsValid)
                return new ServiceResponse<string>(create, validationResult);

            Order Order = _Mapper.Map<Order>(create);
            var Address = await _AddressRepository.GetAsNoTracking(create.AddressId);

            if (Address == null)
                return new ServiceResponse<string>(nameof(create.AddressId), "آدرس مورد نطر یافت نشد");

            if (Address.UserId != create.UserId)
                return new ServiceResponse<string>(nameof(create.AddressId), "آدرس انتخاب شده نادرست میباشد !");

            #region create trackingCode

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(Guid.NewGuid());
            stringBuilder = stringBuilder.Replace("-", "");
            Order.TrackingCode = stringBuilder.ToString().Substring(0, 12);

            #endregion

            #region add tracking statusess

            var TrackingStatuses = new List<TrackingStatus>();
            foreach (var orderStep in EnumExtensions.GetArray<OrderStep>())
            {
                TrackingStatuses.Add(new TrackingStatus
                {
                    Step = orderStep,
                    DoneStatus = DoneStatus.Waiting,
                    DoneDate = null,
                    BaseEntity = new BaseEntity(true),
                });
            }
            Order.TrackingStatuses = TrackingStatuses;

            #endregion

            Order.OrderAddress = Address.ToOrderAddress();
            long orderId = await _OrderRepository.Add(Order, _AppUserProvider.User.Id);

            #region productItems

            // set productItems to ordered and remove from cart
            // decrease products stock
            await _ProductItemRepository.SetOrdered(create.CartId, orderId);

            // add nextCart productItems to Cart
            var nextCartId = (await _NextCartRepository.GetQueryable().FirstOrDefaultAsync(a => a.UserId == create.UserId))?.Id;
            if (nextCartId != null)
            {
                await _ProductItemRepository.TransferFromNextCartToCart(nextCartId.Value, create.CartId);
            }

            #endregion

            #region update discount and coupon usedCount

            if (create.DiscountIdAndProductCount != null)
            {
                if (create.DiscountIdAndProductCount.Any())
                {
                    var discounts = _DiscountRepository.GetQueryableTracking()
                        .Where(a => create.DiscountIdAndProductCount.Select(b => b.Key).Contains(a.Id))
                        .ToList();
                    foreach (var discountIdAndProductCount in create.DiscountIdAndProductCount)
                    {
                        discounts.First(a => a.Id == discountIdAndProductCount.Key).UsedCount += discountIdAndProductCount.Value;
                    }
                    await _DiscountRepository.Update(discounts, _AppUserProvider.User.Id);
                }
            }

            if (create.CouponId > 0)
            {
                Coupon coupon = await _CouponRepository.GetAsTracking(create.CouponId);
                coupon.UsedCount++;
                await _CouponRepository.Update(coupon, _AppUserProvider.User.Id);
            }

            #endregion

            #region update productItem purchasedPrice

            if (create.ProductItemIdAndPrice.Any())
            {
                var productItemIds = create.ProductItemIdAndPrice.Select(a => a.Key);
                var productIems = await _ProductItemRepository.GetQueryableTracking()
                    .Where(a => productItemIds.Contains(a.Id))
                    .ToListAsync();
                foreach (var productItem in productIems)
                {
                    productItem.PurchasedPrice = create.ProductItemIdAndPrice[productItem.Id];
                }
                await _ProductItemRepository.Update(productIems,_AppUserProvider.User.Id);
            }

            #endregion


            return new ServiceResponse<string>(ResponseResult.Success, _Message.SuccessCreate(), Order.TrackingCode);
        }



        public async Task<ServiceResponse<Empty>> Update(UpdateOrderDto update)
        {
            var validationResult = await _ValidatorUpdateOrder.ValidateAsync(update);
            if (!validationResult.IsValid)
                return new ServiceResponse<Empty>(update, validationResult);

            Order? Order = await _OrderRepository.GetAsTracking(update.Id);

            if (Order == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.SuccessUpdate());

            await _OrderRepository.Update(_Mapper.Map<Order>(update), _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse<Empty>> Delete(long delete)
        {
            Order? Order = await _OrderRepository.GetAsTracking(delete);

            if (Order == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.SuccessUpdate());

            await _OrderRepository.SoftDelete(Order, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessDelete());
        }
    }
}
