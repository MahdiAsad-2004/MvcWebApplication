using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Entities.Relations;
using System.ComponentModel;

namespace OrganicShop.Domain.Entities
{
    [DisplayName("تخفیف")]
    public class Discount : EntityId<int>
    {
        public string Title { get; set; }
        public int? Price { get; set; } 
        public int? Percent { get; set; }
        public int? Count { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Priority { get; set; }



        public ICollection<DiscountProducts> DiscountProducts { get; set; }

    }
}
