using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Dtos.OrderDtos;
using AutoMapper;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Enums.EnumValues;
using OrganicShop.Domain.Dtos.ProductItemDtos;
using DryIoc.ImTools;

namespace OrganicShop.BLL.Mappers
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {

            CreateMap<Order, OrderListDto>()
                .ForMember(m => m.UserName, a => a.MapFrom(b => b.Receiver.Name))
                .ForMember(m => m.UserPhoneNumber, a => a.MapFrom(b => b.Receiver.PhoneNumber));


            CreateMap<Order, OrderDetailDto>()
                .ForMember(m => m.CreateDate, a => a.MapFrom(b => b.BaseEntity.CreateDate))
                .ForMember(m => m.OrderItems, a => a.MapFrom(b => b.ProductItems.Select(p => p.ToOrderItemDto()).ToArray()));



            CreateMap<Order, OrderTrackDto>()
                .ForMember(m => m.CreateDate, a => a.MapFrom(b => b.BaseEntity.CreateDate))
                .ForMember(m => m.UserName, a => a.MapFrom(b => b.Receiver.Name))
                .ForMember(m => m.UserName, a => a.MapFrom(b => b.Receiver.Picture != null ? b.Receiver.Picture.Name : PathExtensions.UserDefaultImage))
                .ForMember(m => m.TrackingStatuses, a => a.MapFrom(b => b.TrackingStatuses.ToArray()))
                .ForMember(m => m.TrackingDescriptions, a => a.MapFrom(b => b.TrackingDescriptions.ToArray()));



            CreateMap<CreateOrderDto, Order>();


            CreateMap<UpdateOrderDto, Order>();

        }
    }


    public static class OrderMappers
    {
        public static OrderListDto ToListDto(this Order order)
        {
            return new OrderListDto
            {
                CreateDate = order.BaseEntity.CreateDate.ToPersianDate(),
                DeliveryDatePredicate = order.DeliveryDateEstimated,
                Id = order.Id,
                OrderStatus = order.OrderStatus,
                PaymentMethod = order.PaymentMethod,
                ShippingMethodName = order.ShippingMethodName,
                TotalPrice = order.TotalPrice,
                TrackingCode = order.TrackingCode,
                UserName = order.Receiver.Name,
                UserPhoneNumber = order.Receiver.PhoneNumber,
            };
        }


    }



}
