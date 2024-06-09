using OrganicShop.Domain.Dtos.Combo;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.PropertyDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface IPropertyService : IService<Property>
    {
        Task<ServiceResponse<PageDto<Property, PropertyListDto, long>>> GetAll(FilterPropertyDto? filter = null,PagingDto? paging = null);

        Task<ServiceResponse<UpdatePropertyDto>> Get(long Id);

        //Task<ServiceResponse<Empty>> Create(CreatePropertyDto create);

        //Task<ServiceResponse<Empty>> Update(UpdatePropertyDto update);
        
        //Task<ServiceResponse<Empty>> Delete(long delete);

        //Task<ServiceResponse<List<ComboDto<Property>>>> GetCombos(FilterPropertyDto? filter = null);

    }
}
