using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Response;
using OrganicShop.Domain.Dtos.CartDtos;
using OrganicShop.Domain.Dtos.ProductItemDtos;
using OrganicShop.Domain.Dtos.CouponDtos;

namespace OrganicShop.Domain.IServices
{
    public interface ICartService : IService<Cart>
    {
        Task<ServiceResponse<PageDto<Cart, CartListDto, long>>> GetAll(FilterCartDto? filter = null, PagingDto? paging = null);

        Task<ServiceResponse<CartDetailDto>> GetDetail(long UserId);

        Task<ServiceResponse<CartDetailDto>> GetDetail(long UserId, string couponCode);

        Task<ServiceResponse<CartDetailDto>> GetDetail(List<ProductItemCookieDto> productItemCookieDtos, string? couponCode = null);

        Task<ServiceResponse<Empty>> Create(CreateCartDto create);

        Task<ServiceResponse<Empty>> Update(UpdateCartDto update);

        Task<ServiceResponse<CartDetailDto>> ApplyCoupon(CouponApplyingDto couponApplying);

        Task<ServiceResponse<CartDetailDto>> ApplyCoupon(List<ProductItemCookieDto> productItemCookieDtos , CouponApplyingDto couponApplying);
        
        Task<ServiceResponse<BillDto>> GetBill(long userId, string? couponCode = null);
        
        Task<ServiceResponse<BillDto>> GetBill(List<ProductItemCookieDto> productItemCookieDtos, string? couponCode = null);


        //Task<DeleteEntityResult> Delete(CartDeleteDto delete);

        //Task<ServiceResponse> AddToCart(ProductItem ProductItem);

        //Task<ServiceResponse> AddToCart(List<ProductItem> ProductItems);
    }
}
