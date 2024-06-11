using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;
using System.ComponentModel;

namespace OrganicShop.Domain.Entities.Relations
{
    [DisplayName("کد تخفیف محصول")]
    public class CouponProducts : EntityId<int>
    {
        public int CouponId { get; set; }
        public long ProductsId { get; set; }
        
        
        public Coupon Coupon { get; set; }
        public Product Product { get; set; }
    }
}
