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








        public int CalculateDiscountedPrice(int price)
        {
            if (this.Price != null)
            {
                return price - this.Price.Value;
            }
            else if (this.Percent != null)
            {
                return price - (price * this.Percent.Value / 100);
            }
            throw new Exception("Discount is not valid .");
        }
        public bool IsValid()
        {
            if (BaseEntity.IsActive == false)
                return false;

            if (Count != null)
                if (Count < 1)
                    return false;

            if (StartDate != null)
                if (StartDate.Value > DateTime.Now)
                    return false;

            if (EndDate != null)
                if (EndDate.Value < DateTime.Now)
                    return false;

            if (Price == null && Percent == null)
                return false;

            return true;
        }

    }
}
