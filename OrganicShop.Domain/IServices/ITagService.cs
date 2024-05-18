using OrganicShop.Domain.Dtos.Combo;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.TagDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface ITagService : IService<Tag>
    {
        Task<ServiceResponse<PageDto<Tag, ShishItemListDto, int>>> GetAll(FilterTagDto? filter = null,PagingDto? paging = null);

        Task<ServiceResponse<UpdateTagDto>> Get(int Id);

        Task<ServiceResponse<Empty>> Create(CreateWishItemDto create);

        Task<ServiceResponse<Empty>> Update(UpdateTagDto update);
        
        Task<ServiceResponse<Empty>> Delete(int delete);

        Task<ServiceResponse<List<ComboDto<Tag>>>> GetCombos();

    }
}
