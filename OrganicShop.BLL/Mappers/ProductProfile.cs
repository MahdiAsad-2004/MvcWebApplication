using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Dtos.ProductDtos;
using OrganicShop.BLL.Extensions;
using AutoMapper;
using OrganicShop.Domain.Dtos.ProductDtos;
using OrganicShop.Domain.Dtos.Combo;
using OrganicShop.Domain.Dtos.PictureDtos;
using OrganicShop.Domain.Dtos.PropertyDtos;
using OrganicShop.Domain.Enums;

namespace OrganicShop.BLL.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {

            CreateMap<Product, ProductListDto>()
                .ForMember(m => m.CategoryTitle, a => a.MapFrom(b => b.Category.Title))
                .ForMember(m => m.MainImageName, a => a.MapFrom(b => b.Pictures.GetMainPictureName() ?? string.Empty))
                .ForMember(m => m.IsActive, a => a.MapFrom(b => b.BaseEntity.IsActive));

            CreateMap<Product, ProductSummaryDto>()
               .ForMember(m => m.DiscountedPrice, a => a.MapFrom(b => b.GetDefaultDiscountedPrice() ?? b.Price))
               .ForMember(m => m.CategoryTitle, a => a.MapFrom(b => b.Category.Title))
               .ForMember(m => m.MainImageName, a => a.MapFrom(b => b.Pictures.GetMainPictureName() ?? string.Empty))
               .ForMember(m => m.ImageNames, a => a.MapFrom(b => b.Pictures.Select(p => p.Name).ToArray()))
               .ForMember(m => m.CommentsRate, a => a.MapFrom(b =>  (float)b.Comments.Sum(c => c.Rate) / (float)b.Comments.Count))
               .ForMember(m => m.CommentsCount, a => a.MapFrom(b => b.Comments.Count))
               .ForMember(m => m.PropertiesDictionary, a => a.MapFrom(b => b.Properties.ToDictionary(p => p.Title , p => p.Value)))
               .ForMember(m => m.IsActive, a => a.MapFrom(b => b.BaseEntity.IsActive));


            CreateMap<CreateProductDto, Product>()
                .ForMember(m => m.Description , a => a.MapFrom(b => string.IsNullOrEmpty(b.Description) ? string.Empty : b.Description));



            CreateMap<UpdateProductDto, Product>()
                .ForMember(m => m.Description, a => a.MapFrom(b => string.IsNullOrEmpty(b.Description) ? string.Empty : b.Description));

            CreateMap<Product, UpdateProductDto>()
                .ForMember(m => m.TagIds, a => a.MapFrom(b => b.TagProducts.Select(t => t.TagId).ToArray()))
                .ForMember(m => m.UpdatedPrice, a => a.MapFrom(b => b.GetDefaultDiscountedPriceProduct()))
                .ForMember(m => m.DiscountCount, a => a.MapFrom(b => b.GetDefaultDiscountProduct() != null ? b.GetDefaultDiscountProduct().Count : null))
                .ForMember(m => m.DiscountId, a => a.MapFrom(b => b.GetDefaultDiscountProduct() != null ? b.GetDefaultDiscountProduct().Id : default(int?)))
                .ForMember(m => m.PropertiesDic, a => a.MapFrom(b => b.Properties.ToDictionary(k => k.BaseId.Value,v => new EditPropertyDto {Id = v.Id ,Value = v.Value})))
                .ForMember(m => m.MainPictureName, a => a.MapFrom(b => b.Pictures.First(a => a.IsMain).Name))
                .ForMember(m => m.UnitType, a => a.MapFrom(b => b.UnitValues.Any() ? b.UnitValues.First(u => true).UnitType : UnitType.None))
                .ForMember(m => m.UnitValuesArray, a => a.MapFrom(b => b.UnitValues.Select(a => a.Value).ToArray()))
                .ForMember(m => m.OldPicturesDic, a => a.MapFrom(b => b.Pictures.Where(a => a.IsMain == false).ToDictionary(k => k.Id , v => v.Name)));



            CreateMap<Product, ComboDto<Product>>()
             .ForMember(m => m.Value, a => a.MapFrom(b => b.Id))
             .ForMember(m => m.Text, a => a.MapFrom(b => b.Title));

        }

    }
}