using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.ProductDtos
{
    public class ProductSummaryDto : BaseListDto<long>
    {
        public string Title { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public int DiscountedPrice { get; set; }
        public int SoldCount { get; set; }
        public float CommentsRate { get; set; }
        public int CommentsCount { get; set; }
        public string MainImageName { get; set; }
        public string[] ImageNames { get; set; }
        public string Barcode { get; set; }
        public string CategoryTitle { get; set; }
        public bool IsActive { get; set; }
        public Dictionary<string,string> PropertiesDictionary { get; set; }

        public DateTime DiscountEndDate { get; set; }
    }


}
