using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;
using System.ComponentModel;

namespace OrganicShop.Domain.Entities.Relations
{
    [DisplayName("کد تخفیف دسته بندی")]
    public class CouponCategories : EntityId<int>
    {
        public int CouponId { get; set; }
        public int CategoryId { get; set; }
        
        
        public Coupon Coupon { get; set; }
        public Category Category { get; set; }
    }
}
