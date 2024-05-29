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
using System.Text;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Entities.Base;

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
                query = query.Where(a => a.UserId == filter.UserId);

            if (string.IsNullOrWhiteSpace(filter.UserPhoneNumber))
                query = query.Where(a => EF.Functions.Like(a.Receiver.PhoneNumber, $"%{filter.UserPhoneNumber}%"));

            if (string.IsNullOrWhiteSpace(filter.TrackingCode))
                query = query.Where(a => EF.Functions.Like(a.TrackingCode, $"%{filter.TrackingCode}%"));

            if (filter.OrderStatus != null)
                query = query.Where(a => a.OrderStatus == filter.OrderStatus);

            if (string.IsNullOrWhiteSpace(filter.ShippingMethodName) == false)
                query = query.Where(a => EF.Functions.Like(a.ShippingMethodName , $"%{filter.ShippingMethodName}%"));

            #endregion

            #region sort

            query = filter.ApplySortType(query);

            #endregion

            PageDto<Order, OrderListDto, long> pageDto = new();
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => _Mapper.Map<OrderListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return new ServiceResponse<PageDto<Order, OrderListDto, long>>(ResponseResult.Success,pageDto);
        }



        public async Task<ServiceResponse<OrderDetailDto>> GetDetail(string trackingCode)
        {
            if(string.IsNullOrEmpty(trackingCode))
                return new ServiceResponse<OrderDetailDto>(ResponseResult.NotFound, null);

            var query = _OrderRepository.GetQueryable();

            #region includes

            query = query
                .Include(a => a.ProductItems)
                    .ThenInclude(a => a.Product)
                        .ThenInclude(a => a.Pictures)
                .Include(a => a.ProductItems)
                    .ThenInclude(a => a.Product)
                        .ThenInclude(a => a.ProductVarients)
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
            Order Order = _Mapper.Map<Order>(create);
            var Address = await _AddressRepository.GetAsNoTracking(create.AddressId);

            if (Address == null)
                return new ServiceResponse<string>(ResponseResult.NotFound, _Message.NotFound(),string.Empty);

            Order.OrderAddress = Address.ToOrderAddress();
            long orderId = await _OrderRepository.Add(Order, _AppUserProvider.User.Id);

            #region productItems

            // set productItems to ordered and remove from cart
            // decrease products stock
            var ProductItems = _ProductItemRepository.GetQueryableTracking()
                .Include(a => a.Product)
                    .ThenInclude(a => a.ProductVarients)
                .Where(a => a.CartId == create.CartId);
            foreach (var item in ProductItems)
            {
                item.CartId = null;
                item.OrderId = orderId;
                item.IsOrdered = true;
                if(item.ProductVarientId > 0)
                {
                    item.Product.ProductVarients.First(a => a.Id == item.ProductVarientId).Stock--;
                }
                else
                {
                    item.Product.Stock--;
                }
            }

            // add nextCart productItems to mainCar
            var nextCart = await _CartRepository.GetQueryableTracking()
                .Include(a => a.ProductItems)
                .FirstOrDefaultAsync(a => a.UserId == create.UserId && a.IsMain == false);
            if (nextCart != null)
            {
                foreach (var item in nextCart.ProductItems)
                {
                    item.CartId = create.CartId;
                    await _ProductItemRepository.Update(item, _AppUserProvider.User.Id);
                }
            }

            //saving changes
            await _ProductItemRepository.SaveChanges();



            #endregion


            #region create tracking statuses

            var TrackingStatuses = new List<TrackingStatus>();
            foreach (var orderStep in EnumExtension.GetArray<OrderStep>())
            {
                TrackingStatuses.Add(new TrackingStatus
                {
                    Step = orderStep,
                    DoneStatus = DoneStatus.Waiting,
                    DoneDate = null,
                    OrderId = Order.Id,
                    BaseEntity = new BaseEntity(true),
                });
            }
            Order.TrackingStatuses = TrackingStatuses;

            #endregion


            #region create trackingCode

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(Guid.NewGuid());
            stringBuilder = stringBuilder.Replace("-", "");
            Order.TrackingCode = stringBuilder.ToString()[0..12];

            #endregion

            Order.OrderStatus = OrderStatus.Success;
                return new ServiceResponse<string>(ResponseResult.NotFound, _Message.SuccessUpdate() , Order.TrackingCode);

            return new ServiceResponse<string>(ResponseResult.Success, _Message.SuccessCreate(), string.Empty);
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
