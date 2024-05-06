using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Entities.Relations;
using System.ComponentModel;

namespace OrganicShop.Domain.Entities
{
    [DisplayName("تخفیف")]
    public class Discount : EntityId<int>
    {
        public string Title { get; set; }
        public bool IsDefault { get; set; } 
        public bool IsFixDiscount { get; set; } 
        public string? Code { get; set; }
        public int? Count { get; set; }
        public int? FixValue { get; set; }
        public int? Percent { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool FreeDelivery { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public int Priority { get; set; }



        public ICollection<DiscountCategories> DiscountCategories { get; set; }
        public ICollection<DiscountProducts> DiscountProducts { get; set; }

    }
}
