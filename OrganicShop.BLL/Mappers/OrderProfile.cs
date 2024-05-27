using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Dtos.OrderDtos;
using AutoMapper;
using OrganicShop.Domain.Dtos.OrderDtos;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Enums.EnumValues;

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
                .ForMember(m => m.Address, a => a.MapFrom(b => b.Address))
                .ForMember(m => m.OrderItems, a => a.MapFrom(b => b.ProductItems.Select(p => p.ToOrderItemDto()).ToArray()));


            CreateMap<CreateOrderDto, Order>();


            CreateMap<UpdateOrderDto, Order>();

        }
    }


    public static class OrderMappers
    {
        public static OrderItemDto ToOrderItemDto(this ProductItem productItem)
        {
            var productVarient = productItem.Product.ProductVarients.FirstOrDefault(a => a.Id == productItem.ProductVarientId);
            return new OrderItemDto
            {
                Barcode = productItem.Product.BarCode,
                Count = productItem.Count,
                Id = productItem.Id,
                MainImageName = productItem.Product.Pictures.GetMainPictureName() ?? PathExtensions.ProductDefaultImage,
                Price = productItem.Price,
                Title = productItem.Title,
                VarientType = productVarient?.Type.ToStringValue() ?? null,
                VarientValue = productVarient?.Value ?? null,
            };
        }

    }

}
