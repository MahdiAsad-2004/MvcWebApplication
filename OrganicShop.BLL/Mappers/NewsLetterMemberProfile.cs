
using OrganicShop.Domain.Entities;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Dtos.NewsLetterMemberDtos;
using AutoMapper;
using OrganicShop.Domain.Dtos.Combo;
using OrganicShop.Domain.Dtos.NotificationDtos;

namespace OrganicShop.BLL.Mappers
{
    public class NewsLetterMemberProfile : Profile
    {
        public NewsLetterMemberProfile()
        {

            CreateMap<NewsLetterMember, NewsLetterMemberListDto>()
                .ForMember(m => m.UserName , a => a.MapFrom(b => b.User != null ? b.User.Name : "-"))
                .ForMember(m => m.SubscribeDate , a => a.MapFrom(b => b.BaseEntity.CreateDate.ToPersianDate()));


            CreateMap<CreateNewsLetterMemberDto, NewsLetterMember>();


            CreateMap<UpdateNewsLetterMemberDto, NewsLetterMember>()
                .ForPath(m => m.BaseEntity.IsActive, a => a.MapFrom(b => b.IsActive));

        }


    }
}
