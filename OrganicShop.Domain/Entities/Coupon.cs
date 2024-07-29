using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Entities.Relations;
using System.ComponentModel;

namespace OrganicShop.Domain.Entities
{
    [DisplayName("کد تخفیف")]
    public class Coupon : EntityId<int>
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public bool FreeDelivery { get; set; }
        public int? Price { get; set; } 
        public int? Percent { get; set; }
        public int? Count { get; set; }
        public int UsedCount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? MaxCost { get; set; }
        public int? MinCost { get; set; }



        public ICollection<CouponCategories> CouponCategories { get; set; }

    }
}
