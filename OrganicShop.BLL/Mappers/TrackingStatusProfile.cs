using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Dtos.TrackingStatusDtos;
using AutoMapper;
using OrganicShop.Domain.Dtos.TrackingStatusDtos;

namespace OrganicShop.BLL.Mappers
{
    public class TrackingStatusProfile : Profile
    {
        public TrackingStatusProfile()
        {

            CreateMap<TrackingStatus, TrackingStatusListDto>();


            CreateMap<CreateTrackingStatusDto, TrackingStatus>();


            CreateMap<UpdateTrackingStatusDto, TrackingStatus>();

        }


    }
}
