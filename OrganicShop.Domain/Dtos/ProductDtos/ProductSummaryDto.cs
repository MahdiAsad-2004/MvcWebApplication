using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Dtos.PropertyDtos;
using OrganicShop.Domain.Entities;
using System.Diagnostics.Contracts;

namespace OrganicShop.Domain.Dtos.ProductDtos
{
    public class ProductSummaryDto : BaseListDto<long>
    {
        public string Title { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public string ShortDescription { get; set; }
        public int? DiscountedPrice { get; set; }
        public int SoldCount { get; set; }
        public float CommentsRate { get; set; }
        public int CommentsCount { get; set; }
        public string MainImageName { get; set; }
        public string[] ImageNames { get; set; }
        public string Barcode { get; set; }
        public bool IsActive { get; set; }
        public Discount? Discount { get; set; }
        public Category[] Categories { get; set; }
        public PropertyListDto[] Properties { get; set; }
        public ProductVarient[] Varients { get; set; }
        
    

    }


}
