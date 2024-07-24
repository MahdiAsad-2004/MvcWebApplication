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
                .ForMember(m => m.Id, a => a.MapFrom(b => b.Id))
                .ForMember(m => m.Title, a => a.MapFrom(b => b.Product.Title))
                .ForMember(m => m.Price, a => a.MapFrom(b => b.Product.Price))
                .ForMember(m => m.Stock, a => a.MapFrom(b => b.Product.Stock))
                .ForMember(m => m.MainImageName, a => a.MapFrom(b => b.Product.Pictures.GetMainPictureName() ?? PathExtensions.ProductDefaultImage))
                .ForMember(m => m.VarientValue, a => a.MapFrom(b =>
                    b.ProductVarientId > 0 ? b.Product.ProductVarients.First(p => p.Id == b.ProductVarientId).Value : null))
                .ForMember(m => m.VarientType, a => a.MapFrom(b =>
                    b.ProductVarientId > 0 ? b.Product.ProductVarients.First(p => p.Id == b.ProductVarientId).Type.ToStringValue() : null))
                //.ForMember(m => m.DiscountedPrice , a => a.MapFrom(b => b.Product.ToModel().DiscountedPrice))
                .ForMember(m => m.DiscountedPrice , a => a.MapFrom(b => b.Product.DiscountedPrice))
                .ForMember(m => m.Barcode, a => a.MapFrom(b => b.Product.Barcode));


            CreateMap<CreateProductItemDto, ProductItem>();


            CreateMap<UpdateProductItemDto, ProductItem>();



            CreateMap<CreateProductItemDto, ProductItemCookieDto>();

        }


    }


    public static class ProductItemMappers
    {
        public static OrderItemDto ToOrderItemDto(this ProductItem productItem)
        {
            var productVarient = productItem.Product.ProductVarients.FirstOrDefault(a => a.Id == productItem.ProductVarientId);
            return new OrderItemDto
            {
                Barcode = productItem.Product.Barcode,
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
