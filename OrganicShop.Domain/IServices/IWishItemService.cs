using OrganicShop.Domain.Dtos.Combo;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.WishItemDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Relations;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface IWishItemService : IService<WishItem>
    {
        Task<ServiceResponse<PageDto<WishItem, WishItemListDto, long>>> GetAll(FilterWishItemDto? filter = null,PagingDto? paging = null);

        Task<ServiceResponse<Empty>> Create(CreateWishItemDto create);
        
        Task<ServiceResponse<Empty>> Delete(long productId);

        Task<ServiceResponse<long[]>> GetUserWishProductIds();

    }
}
