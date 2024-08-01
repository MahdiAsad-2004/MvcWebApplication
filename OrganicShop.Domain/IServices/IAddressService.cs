using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;
using System.Xml.Schema;

namespace OrganicShop.Domain.IServices
{
    public interface IAddressService : IService<Address>
    {
        Task<ServiceResponse<PageDto<Address, AddressListDto, long>>> GetAll(FilterAddressDto? filter = null ,PagingDto? paging = null);

        Task<ServiceResponse<UpdateAddressDto>> Get(long Id);

        Task<ServiceResponse<Empty>> Create(CreateAddressDto create);

        Task<ServiceResponse<Empty>> Update(UpdateAddressDto update);
        
        Task<ServiceResponse<Empty>> Delete(long delete);
        
    }
}
