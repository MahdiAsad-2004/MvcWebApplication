using OrganicShop.Domain.Entities;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Dtos.NotificationDtos;
using AutoMapper;
using OrganicShop.Domain.Dtos.Combo;

namespace OrganicShop.BLL.Mappers
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {

            CreateMap<Notification, NotificationListDto>()
                .ForMember(m => m.IsActive, a => a.MapFrom(b => b.BaseEntity.IsActive));


            CreateMap<CreateNotificationDto, Notification>();
                //.ForPath(m => m.BaseEntity.IsActive, a => a.MapFrom(b => b.IsActive));


            CreateMap<UpdateNotificationDto, Notification>()
                .ForPath(m => m.BaseEntity.IsActive, a => a.MapFrom(b => b.IsActive));


            CreateMap<Notification, UpdateNotificationDto>()
                .ForMember(m => m.IsActive, a => a.MapFrom(b => b.BaseEntity.IsActive));


        }


    }
}
