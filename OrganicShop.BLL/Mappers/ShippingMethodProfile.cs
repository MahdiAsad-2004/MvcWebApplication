using OrganicShop.Domain.Entities;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Dtos.SellerDtos;
using AutoMapper;
using OrganicShop.Domain.Dtos.Combo;
using OrganicShop.Domain.Dtos.NotificationDtos;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Enums.EnumValues;
using OrganicShop.Domain.Dtos.ShippingMethodDtos;

namespace OrganicShop.BLL.Mappers
{
    public class ShippingMethodProfile : Profile
    {
        public ShippingMethodProfile()
        {

            CreateMap<ShippingMethod, ShippingMethodListDto>();

        }
    }


    

}
