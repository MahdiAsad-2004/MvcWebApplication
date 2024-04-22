using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.ProductItemDtos
{
    public class ProductItemListDto : BaseListDto<long>
    {
        public string Title { get; set; }
        public long ProductId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public int? UpdatedPrice { get; set; }
        public long? CartId { get; set; }
    }

}
