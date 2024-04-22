using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.ProductDtos
{
    public class ProductListDto : BaseListDto<long>
    {
        public string Title { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public int DiscountedPrice { get; set; }
        public int SoldCount { get; set; }
        public string MainImageName { get; set; }
        public string[] ImageNames { get; set; }
        public string Barcode { get; set; }
        public string CategoryTitle { get; set; }
        public bool IsActive { get; set; }

    }


}
