using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.ProductItemDtos
{
    public class ProductItemCookieDto : BaseDto
    {
        public long ProductId { get; set; }
        public long? ProductVarientId { get; set; }
        public int Count { get; set; }

    }

}
