
using OrganicShop.Domain.Entities;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Dtos.NewsLetterDtos;
using AutoMapper;
using OrganicShop.Domain.Dtos.Combo;
using OrganicShop.Domain.Dtos.NotificationDtos;

namespace OrganicShop.BLL.Mappers
{
    public class NewsLetterProfile : Profile
    {
        public NewsLetterProfile()
        {

            CreateMap<NewsLetter, NewsLetterListDto>()
                .ForMember(m => m.IsSent , a => a.MapFrom(b => b.SendDate >= DateTime.Now));


            CreateMap<CreateNewsLetterDto, NewsLetter>()
                .ForPath(m => m.BaseEntity.IsActive, a => a.MapFrom(b => b.IsActive));


            CreateMap<UpdateNewsLetterDto, NewsLetter>() 
                .ForPath(m => m.BaseEntity.IsActive , a => a.MapFrom(b => b.IsActive));


            CreateMap<NewsLetter, UpdateNewsLetterDto>()
                .ForMember(m => m.IsActive , a => a.MapFrom(b => b.BaseEntity.IsActive));


        }


    }
}
