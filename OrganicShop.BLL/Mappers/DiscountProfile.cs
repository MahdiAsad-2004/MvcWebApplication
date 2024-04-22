using AutoMapper;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Dtos.DiscountDtos;
using OrganicShop.Domain.Dtos.DiscountDtos;
using OrganicShop.Domain.Entities;

namespace OrganicShop.BLL.Mappers
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {

            CreateMap<Discount, DiscountListDto>()
                .ForMember(m => m.CreateDate, a => a.MapFrom(b => b.BaseEntity.CreateDate))
                .ForMember(m => m.Code, a => a.MapFrom(b => b.Code ?? "-"))
                .ForMember(m => m.Code, a => a.MapFrom(b => b.Count == null ? "_" : b.Count.ToString()))
                .ForMember(m => m.StartDate, a => a.MapFrom(b => b.StartDate ?? b.StartDate.ToPersianDate()))
                .ForMember(m => m.EndDate, a => a.MapFrom(b => b.EndDate ?? b.EndDate.ToPersianDate()))
                .ForMember(m => m.IsActive, a => a.MapFrom(b => b.BaseEntity.IsActive));


            CreateMap<Discount, UpdateDiscountDto>()
                .ForMember(m => m.ProductIds, a => a.MapFrom(b => b.DiscountProducts.Select(s => s.ProductId).ToArray()))
                .ForMember(m => m.CategoryIds, a => a.MapFrom(b => b.DiscountCategories.Select(s => s.CategoryId).ToArray()));


            CreateMap<CreateDiscountDto, Discount>();


            CreateMap<UpdateDiscountDto, Discount>();

        }


    }
}
