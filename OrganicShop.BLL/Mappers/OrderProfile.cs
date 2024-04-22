using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Dtos.OrderDtos;
using AutoMapper;
using OrganicShop.Domain.Dtos.OrderDtos;

namespace OrganicShop.BLL.Mappers
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {

            CreateMap<Order, OrderListDto>()
                .ForMember(m => m.UserName, a => a.MapFrom(b => b.Receiver.Name))
                .ForMember(m => m.UserPhoneNumber, a => a.MapFrom(b => b.Receiver.PhoneNumber));


            CreateMap<CreateOrderDto, Order>();


            CreateMap<UpdateOrderDto, Order>();

        }


    }
}
