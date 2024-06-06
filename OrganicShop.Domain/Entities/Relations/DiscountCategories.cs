using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;
using System.ComponentModel;

namespace OrganicShop.Domain.Entities.Relations
{
    [DisplayName("تخفیف دسته بندی")]
    public class DiscountCategories : EntityId<int>
    {
        public int DiscountId { get; set; }
        public int CategoryId { get; set; }
        
        
        public Discount Discount { get; set; }
        public Category Category { get; set; }
    }
}
