using Microsoft.EntityFrameworkCore;
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

namespace OrganicShop.BLL.Services
{
    public class OrderService : Service<Order>, IOrderService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly IOrderRepository _OrderRepository;
        private readonly IAddressRepository _AddressRepository;
        private readonly IProductItemRepository _ProductItemRepository;
        private readonly ICartRepository _CartRepository;
        private readonly ITrackingStatusService _TrackingStatusesService;

        public OrderService(IApplicationUserProvider provider,IMapper mapper,IOrderRepository OrderRepository, IAddressRepository AddressRepository,
            IProductItemRepository ProductItemRepository, ICartRepository CartRepository, ITrackingStatusService trackingStatusesService) : base(provider)
        {
            _Mapper = mapper;
            _OrderRepository = OrderRepository;
            _AddressRepository = AddressRepository;
            _ProductItemRepository = ProductItemRepository;
            _CartRepository = CartRepository;
            _TrackingStatusesService = trackingStatusesService;
        }

        #endregion


        public async Task<ServiceResponse<PageDto<Order, OrderListDto, long>>> GetAll(FilterOrderDto? filter = null, PagingDto? paging = null)
        {
            var query = _OrderRepository.GetQueryable()
                .Include(a => a.Receiver)
                .AsQueryable();

            if (filter == null) filter = new FilterOrderDto();
            if (paging == null) paging = new PagingDto();

            #region flters

            query = filter.ApplyBaseFilters(query);

            if (filter.UserId > 0)
                query = query.Where(a => a.ReceiverId == filter.UserId);

            if (filter.UserPhoneNumber != null)
                query = query.Where(a => EF.Functions.Like(a.Receiver.PhoneNumber, $"%{filter.UserPhoneNumber}%"));

            if (filter.TrackingCode != null)
                query = query.Where(a => EF.Functions.Like(a.TrackingCode, $"%{filter.TrackingCode}%"));

            if (filter.OrderStatus != null)
                query = query.Where(a => a.OrderStatus == filter.OrderStatus);

            if (filter.DeliveryType != null)
                query = query.Where(a => a.DeliveryType == filter.DeliveryType);

            #endregion

            #region sort

            query = filter.ApplySortType(query);

            #endregion

            PageDto<Order, OrderListDto, long> pageDto = new();
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => _Mapper.Map<OrderListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return new ServiceResponse<PageDto<Order, OrderListDto, long>>(ResponseResult.Success,pageDto);
        }



        public async Task<ServiceResponse<Empty>> Create(CreateOrderDto create)
        {
            Order Order = _Mapper.Map<Order>(create);
            var Address = await _AddressRepository.GetAsNoTracking(create.AddressId);

            if (Address == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            Order.Address = Address;
            long orderId = await _OrderRepository.Add(Order, _AppUserProvider.User.Id);

            #region transfer coProdutcs from Cart to order

            var ProductItems = _ProductItemRepository.GetQueryable()
                .Where(a => a.CartId == create.CartId)
                .AsTracking();
            foreach (var item in ProductItems)
            {
                item.CartId = null;
                item.OrderId = orderId;
                item.IsOrdered = true;
                await _ProductItemRepository.Update(item, _AppUserProvider.User.Id);
            }

            #endregion


            #region transfer nextCart ProductItems to mainCart

            var nextCart = await _CartRepository.GetQueryable()
                .Include(a => a.ProductItems)
                .FirstOrDefaultAsync(a => a.UserId == create.UserId);
            if (nextCart != null)
            {
                foreach (var item in nextCart.ProductItems)
                {
                    item.CartId = create.CartId;
                    await _ProductItemRepository.Update(item, _AppUserProvider.User.Id);
                }
            }

            #endregion


            #region create tracking statuses

            var result1 = await _TrackingStatusesService.Create(new CreateTrackingStatusDto { OrderId = orderId });

            #endregion


            if (result1.Result != ResponseResult.Success) 
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.SuccessUpdate());

            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse<Empty>> Update(UpdateOrderDto update)
        {
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
