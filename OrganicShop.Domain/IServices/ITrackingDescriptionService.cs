using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.TrackingDescriptionDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;


namespace OrganicShop.Domain.IServices
{
    public interface ITrackingDescriptionService : IService<TrackingDescription>
    {
        Task<ServiceResponse<PageDto<TrackingDescription, TrackingDescriptionListDto, long>>> GetAll
            (FilterTrackingDescriptionDto? filter = null, PagingDto? paging = null);

        Task<ServiceResponse<Empty>> Create(CreateTrackingDescriptionDto create);

        Task<ServiceResponse<Empty>> Update(UpdateTrackingDescriptionDto update);
        
        Task<ServiceResponse<Empty>> Delete(long delete);
        
    }
}
