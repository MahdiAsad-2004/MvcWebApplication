using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Dtos.ProductItemDtos;
using AutoMapper;
using OrganicShop.Domain.Dtos.ProductItemDtos;

namespace OrganicShop.BLL.Mappers
{
    public class ProductItemProfile : Profile
    {
        public ProductItemProfile()
        {

            CreateMap<ProductItem, ProductItemListDto>()
                .ForMember(m => m.Price, a => a.MapFrom(b => b.Product.Price));
                //.ForMember(m => m.UpdatedPrice , a => a.MapFrom(b => b.Product.UpdatedPrice));


            CreateMap<CreateProductItemDto, ProductItem>();


            CreateMap<UpdateProductItemDto, ProductItem>();

        }


    }
}
