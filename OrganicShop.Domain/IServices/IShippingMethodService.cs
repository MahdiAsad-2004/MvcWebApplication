using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.ShippingMethodDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface IShippingMethodService : IService<ShippingMethod>
    {
        Task<ServiceResponse<List<ShippingMethodListDto>>> GetAll();

        Task<ServiceResponse<ShippingMethodListDto>> Get(byte deliveryId);

        Task<ServiceResponse<Empty>> Create(CreateShippingMethodDto create);

        Task<ServiceResponse<Empty>> Update(UpdateShippingMethodDto update);
        
        Task<ServiceResponse<Empty>> Delete(byte delete);
        
    }
}
