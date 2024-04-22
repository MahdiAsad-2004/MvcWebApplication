using OrganicShop.Domain.Dtos.ContactUsDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface IContactUsService : IService<ContactUs>
    {
        Task<ServiceResponse<Empty>> Update(UpdateContactUsDto update);
       
        Task<ServiceResponse<UpdateContactUsDto>> Get();
    }
}
