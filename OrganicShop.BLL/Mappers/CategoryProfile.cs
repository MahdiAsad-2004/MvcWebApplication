using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.EnumValues;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Dtos.CategoryDtos;
using AutoMapper;
using OrganicShop.Domain.Dtos.CategoryDtos;
using OrganicShop.Domain.Dtos.Combo;

namespace OrganicShop.BLL.Mappers
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {

            CreateMap<Category, CategoryListDto>()
                .ForMember(m => m.CreateDate, a => a.MapFrom(b => b.BaseEntity.CreateDate.ToPersianDate()))
                .ForMember(m => m.Type, a => a.MapFrom(b => b.Type.ToStringValue()))
                .ForMember(m => m.ImageName, a => a.MapFrom(b => b.Picture != null ? b.Picture.Name : string.Empty))
                .ForMember(m => m.ProductsCount, a => a.MapFrom(b => b.Products.Count))
                .ForMember(m => m.ParentTitle, a => a.MapFrom(b => b.Parent != null ? b.Parent.Title : null));


            CreateMap<CreateCategoryDto, Category>();


            CreateMap<UpdateCategoryDto, Category>();


            CreateMap<Category,UpdateCategoryDto>()
                .ForMember(m => m.ImageName, a => a.MapFrom(b => b.Picture.Name));


            CreateMap<Category, ComboDto<Category>>()
                .ForMember(m => m.Value, a => a.MapFrom(b => b.Id))
                .ForMember(m => m.Text, a => a.MapFrom(b => b.Title));


        }


    }
}
