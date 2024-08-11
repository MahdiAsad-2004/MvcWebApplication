using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;

namespace OrganicShop.Domain.Dtos.ProductItemDtos
{
    public class ProductItemListDto : BaseListDto<long>
    {
        public string ProductTitle { get; set; }
        public string ProductMainImageName { get; set; }
        public long ProductId { get; set; }
        public string ProductBarcode { get; set; }
        public int ProductStock { get; set; }
        public int ProductPrice { get; set; }
        public int? ProductDiscountedPrice { get; set; }
        public int? ProductDiscounteId { get; set; }
        public int Count { get; set; }
        public long? CartId { get; set; }
   
    }

}
