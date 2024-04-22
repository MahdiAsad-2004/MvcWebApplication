using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;

namespace OrganicShop.Domain.Dtos.CartDtos
{
    public class CartDetailDto : BaseListDto<long>
    {
        public int TotalPrice { get; set; }
        public long UserId { get; set; }
        public List<ProductItem> ProductItems { get; set; }
    }



}
