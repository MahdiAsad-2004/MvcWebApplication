using OrganicShop.Domain.Dtos.Combo;
using OrganicShop.Domain.Dtos.DiscountDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.ProductDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface IProductService : IService<Product>
    {
        Task<ServiceResponse<PageDto<Product, ProductListDto, long>>> GetAll(FilterProductDto? filter = null,PagingDto? paging = null);

        Task<ServiceResponse<UpdateProductDto>> Get(long Id);

        Task<ServiceResponse<Empty>> Create(CreateProductDto create);

        Task<ServiceResponse<Empty>> Update(UpdateProductDto update);
        
        Task<ServiceResponse<Empty>> Delete(long delete);

        Task<ServiceResponse<List<ComboDto<Product>>>> GetCombos();
        
        Task<ServiceResponse<List<ComboDto<Product>>>> GetCombos(long[] productIds);

    }
}
