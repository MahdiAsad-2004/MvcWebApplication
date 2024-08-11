using OrganicShop.Domain.Dtos.ProductItemDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface IProductItemService : IService<ProductItem>
    {
        Task<ServiceResponse<List<ProductItemListDto>>> GetAll(FilterProductItemDto? filter = null);

        Task<ServiceResponse<Empty>> Create(CreateProductItemDto create);

        Task<ServiceResponse<Empty>> Update(UpdateProductItemDto update);

        Task<ServiceResponse<Empty>> Delete(long id);

        Task<ServiceResponse<List<ProductItemListDto>>> GetAll(List<ProductItemCookieDto> productItemCookieDtos);

        Task<ServiceResponse<List<ProductItemCookieDto>>> CreateForCookie(CreateProductItemDto create, List<ProductItemCookieDto> previousProductItems);

        Task<ServiceResponse<List<ProductItemCookieDto>>> UpdateForCookie(long productItemId, int count, List<ProductItemCookieDto> previousProductItems);

        Task<ServiceResponse<Empty>> AddToNextCart(long Id);


    }
}
