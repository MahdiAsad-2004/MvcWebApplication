using OrganicShop.Domain.Dtos.Combo;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.PermissionDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface IPermissionService : IService<Permission>
    {
        Task<ServiceResponse<PageDto<Permission, PermissionListDto, byte>>> GetAll(FilterPermissionDto? filter = null,PagingDto? paging = null);

        Task<ServiceResponse<Empty>> Create(CreatePermissionDto create);

        Task<ServiceResponse<Empty>> Update(UpdatePermissionDto update);
        
        Task<ServiceResponse<Empty>> Delete(byte delete);

        Task<ServiceResponse<List<ComboDto<Permission>>>> GetCombos();
    }
}
