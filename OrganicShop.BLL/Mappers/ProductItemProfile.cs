using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Dtos.ProductItemDtos;
using AutoMapper;
using OrganicShop.Domain.Dtos.ProductItemDtos;
using OrganicShop.Domain.Enums.EnumValues;
using OrganicShop.BLL.Extensions;

namespace OrganicShop.BLL.Mappers
{
    public class ProductItemProfile : Profile
    {
        public ProductItemProfile()
        {

            CreateMap<ProductItem, ProductItemListDto>()
                .ForMember(m => m.Price, a => a.MapFrom(b => b.Product.Price))
                .ForMember(m => m.MainImageName, a => a.MapFrom(b => b.Product.Pictures.GetMainPictureName() ?? PathExtensions.ProductDefaultImage))
                .ForMember(m => m.VarientValue, a => a.MapFrom(b => 
                    b.ProductVarientId > 0 ? b.Product.ProductVarients.First(p => p.Id == b.ProductVarientId).Value : null))
                .ForMember(m => m.VarientType, a => a.MapFrom(b => 
                    b.ProductVarientId > 0 ? b.Product.ProductVarients.First(p => p.Id == b.ProductVarientId).Type.ToStringValue() : null))
                .ForMember(m => m.DiscountedPrice , a => a.MapFrom(b => b.Product.ToModel().DiscountedPrice));


            CreateMap<CreateProductItemDto, ProductItem>();


            CreateMap<UpdateProductItemDto, ProductItem>();

        }


    }
}
