using OrganicShop.Domain.Dtos.DeliveryDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface IDeliveryService : IService<Delivery>
    {
        Task<ServiceResponse<List<DeliveryListDto>>> GetAll();

        Task<ServiceResponse<DeliveryListDto>> Get(byte deliveryId);

        Task<ServiceResponse<Empty>> Create(CreateDeliveryDto create);

        Task<ServiceResponse<Empty>> Update(UpdateDeliveryDto update);
        
        Task<ServiceResponse<Empty>> Delete(byte delete);
        
    }
}
