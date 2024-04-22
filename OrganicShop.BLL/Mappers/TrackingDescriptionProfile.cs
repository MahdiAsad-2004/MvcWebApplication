using AutoMapper;
using OrganicShop.Domain.Dtos.TrackingDescriptionDtos;
using OrganicShop.Domain.Dtos.TrackingDescriptionDtos;
using OrganicShop.Domain.Entities;

namespace OrganicShop.BLL.Mappers
{
    public class TrackingDescriptionProfile : Profile
    {
        public TrackingDescriptionProfile()
        {

            CreateMap<TrackingDescription, TrackingDescriptionListDto>();


            CreateMap<CreateTrackingDescriptionDto, TrackingDescription>();


            CreateMap<UpdateTrackingDescriptionDto, TrackingDescription>();

        }


    }
}
