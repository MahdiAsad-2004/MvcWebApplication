using OrganicShop.Domain.Dtos.ProductItemDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface IProductItemService : IService<ProductItem>
    {
        Task<ServiceResponse<PageDto<ProductItem, ProductItemListDto, long>>> GetAll(FilterProductItemDto? filter = null, PagingDto? paging = null);

        Task<ServiceResponse<Empty>> Create(CreateProductItemDto create);

        Task<ServiceResponse<Empty>> Update(UpdateProductItemDto update);
        
        Task<ServiceResponse<Empty>> Delete(long id);
        
    }
}
