using OrganicShop.Domain.Entities;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Dtos.WishItemDtos;
using AutoMapper;
using OrganicShop.Domain.Dtos.Combo;
using OrganicShop.Domain.Dtos.NotificationDtos;
using OrganicShop.Domain.Entities.Relations;

namespace OrganicShop.BLL.Mappers
{
    public class WishItemProfile : Profile
    {
        public WishItemProfile()
        {

            CreateMap<CreateWishItemDto, WishItem>();

               
        }


    }
}
