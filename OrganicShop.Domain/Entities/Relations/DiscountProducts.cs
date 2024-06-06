using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;
using System.ComponentModel;

namespace OrganicShop.Domain.Entities.Relations
{
    [DisplayName("تخفیف محصول")]
    public class DiscountProducts : EntityId<int>
    {
        public int DiscountId { get; set; }
        public long ProductId { get; set; }
        
        
        public Discount Discount { get; set; }
        public Product Product { get; set; }
    }
}
