using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Response;
using OrganicShop.Domain.Dtos.CartDtos;

namespace OrganicShop.Domain.IServices
{
    public interface ICartService : IService<Cart>
    {
        Task<ServiceResponse<PageDto<Cart, CartListDto, long>>> GetAll(FilterCartDto? filter = null, PagingDto? paging = null);

        Task<ServiceResponse<Empty>> Create(CreateCartDto create);

        Task<ServiceResponse<Empty>> Update(UpdateCartDto update);


        //Task<DeleteEntityResult> Delete(CartDeleteDto delete);

        //Task<ServiceResponse> AddToCart(ProductItem ProductItem);

        //Task<ServiceResponse> AddToCart(List<ProductItem> ProductItems);
    }
}
