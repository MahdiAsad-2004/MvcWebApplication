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
        public int? Price { get; set; }
        public int? Percent { get; set; }
        public int? Count { get; set; }
        public int UsedCount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? MaxCost { get; set; }
        public int? MinCost { get; set; }



        public ICollection<CouponCategories> CouponCategories { get; set; }








        public int GetAmount(int cost)
        {
            if (Price != null)
                return Price.Value;

            if (Percent != null)
                return cost * Percent.Value / 100;

            throw new Exception("coupon does not have price(fixValue) nor percent");
        }



        public bool IsValid(int totalCost)
        {
            if (Count != null)
                if (UsedCount >= Count)
                    return false;

            if (StartDate != null)
                if (StartDate.Value > DateTime.Now)
                    return false;

            if (EndDate != null)
                if (EndDate.Value < DateTime.Now)
                    return false;

            if (MinCost != null)
                if (MinCost.Value > totalCost)
                    return false;

            if (MaxCost != null)
                if (MaxCost.Value < totalCost)
                    return false;

            return true;
        }


        public bool IsAcceptableForProducts(List<Product> products)
        {
            var acceptedCategoryIds = this.CouponCategories.Select(a => a.CategoryId);

            if(acceptedCategoryIds.Any() == false || products.Any() == false)
                return true;

            var isAccepted = true;
            foreach (var product in products)
            {
                foreach (var catgoryId in product.Categories.Select(a => a.Id))
                {
                    if (acceptedCategoryIds.Contains(catgoryId))
                    {
                        isAccepted = true;
                        break;
                    }
                    isAccepted = false;
                }
                if (isAccepted == false)
                    return false;
            }
            return true;
        }


        public static bool IsAcceptableForProducts(int[] acceptedCategoryIds, List<Product> products)
        {
            if (acceptedCategoryIds.Any() == false )
                return true;
            
            var isAccepted = true;

            foreach (var product in products)
            {
                foreach (var catgoryId in product.Categories.Select(a => a.Id))
                {
                    if (acceptedCategoryIds.Contains(catgoryId))
                    {
                        isAccepted = true;
                        break;
                    }
                    isAccepted = false;
                }
                if (isAccepted == false)
                    return false;
            }
            return true;
        }



    }
}
