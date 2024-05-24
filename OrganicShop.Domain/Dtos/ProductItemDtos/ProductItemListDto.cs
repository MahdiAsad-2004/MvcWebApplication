using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;

namespace OrganicShop.Domain.Dtos.ProductItemDtos
{
    public class ProductItemListDto : BaseListDto<long>
    {
        public string Title { get; set; }
        public string MainImageName { get; set; }
        public long ProductId { get; set; }
        public long Barcode { get; set; }
        public int Count { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public int? DiscountedPrice { get; set; }
        public long? CartId { get; set; }
        public string? VarientType { get; set; }
        public string? VarientValue { get; set; }
    }

}
