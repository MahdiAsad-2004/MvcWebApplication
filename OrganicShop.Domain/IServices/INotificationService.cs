using OrganicShop.Domain.Dtos.Combo;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.NotificationDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface INotificationService : IService<Notification>
    {
        Task<ServiceResponse<PageDto<Notification, NotificationListDto, int>>> GetAll(FilterNotificationDto? filter = null,PagingDto? paging = null);

        Task<ServiceResponse<UpdateNotificationDto>> Get(int Id);

        Task<ServiceResponse<Empty>> Create(CreateNotificationDto create);

        Task<ServiceResponse<Empty>> Update(UpdateNotificationDto update);
        
        Task<ServiceResponse<Empty>> Delete(int delete);

    }
}
