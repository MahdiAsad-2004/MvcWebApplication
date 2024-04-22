using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Dtos.CartDtos;
using AutoMapper;

namespace OrganicShop.BLL.Mappers
{
    public class CartProfile : Profile
    {

        public CartProfile()
        {

            CreateMap<Cart, CartListDto>()
                .ForMember(m => m.ProductsCount , a => a.MapFrom(b => b.ProductItems.Count));


            CreateMap<Cart, CartDetailDto>();


            CreateMap<CreateCartDto, Cart>();


            CreateMap<UpdateCartDto, Cart>();

        }




    }
}
