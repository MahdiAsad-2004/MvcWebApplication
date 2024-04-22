using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.TrackingStatusDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface ITrackingStatusService : IService<TrackingStatus>
    {
        Task<ServiceResponse<PageDto<TrackingStatus, TrackingStatusListDto, long>>> GetAll(FilterTrackingStatusDto? filter = null,PagingDto? paging = null);

        Task<ServiceResponse<Empty>> Create(CreateTrackingStatusDto create);

        Task<ServiceResponse<Empty>> Update(UpdateTrackingStatusDto update);
        
        Task<ServiceResponse<Empty>> Delete(long delete);
        
    }
}
