using OrganicShop.Domain.Entities;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Dtos.UserMessageDtos;
using AutoMapper;
using OrganicShop.Domain.Dtos.Combo;
using OrganicShop.Domain.Dtos.NotificationDtos;

namespace OrganicShop.BLL.Mappers
{
    public class UserMessageProfile : Profile
    {
        public UserMessageProfile()
        {

            CreateMap<UserMessage, UserMessageListDto>();


            CreateMap<CreateUserMessageDto, UserMessage>()
                .ForMember(m => m.Name , a => a.MapFrom(b => $"{b.FirstName} {b.LastName}"));

        }


    }
}
