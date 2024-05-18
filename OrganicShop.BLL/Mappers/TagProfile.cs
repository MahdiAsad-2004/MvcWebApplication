using OrganicShop.Domain.Entities;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Dtos.TagDtos;
using AutoMapper;
using OrganicShop.Domain.Dtos.Combo;
using OrganicShop.Domain.Dtos.NotificationDtos;

namespace OrganicShop.BLL.Mappers
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {

            CreateMap<Tag, TagListDto>();


            CreateMap<TagListDto, Tag>();


            CreateMap<UpdateTagDto, Tag>() //;
                .ForPath(m => m.BaseEntity.IsActive , a => a.MapFrom(b => b.IsActive));


            CreateMap<Tag, UpdateTagDto>()
                .ForMember(m => m.IsActive , a => a.MapFrom(b => b.BaseEntity.IsActive));


            CreateMap<Tag, ComboDto<Tag>>()
               .ForMember(m => m.Value, a => a.MapFrom(b => b.Id))
               .ForMember(m => m.Text, a => a.MapFrom(b => b.Title));
        }


    }
}
