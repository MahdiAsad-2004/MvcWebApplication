using Microsoft.Identity.Client;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Relations;

namespace OrganicShop.BLL.Extensions
{
    public static class DiscountExtensions
    {
        public static int GetDiscountedPrice(this Discount discount, int price)
        {
            if (discount.Price != null)
            {
                return price - discount.Price.Value;
            }
            else if (discount.Percent != null)
            {
                return price - (price * discount.Percent.Value / 100);
            }
            throw new Exception("Discount is not valid .");
        }


        public static bool IsDiscountValid(this Discount discount)
        {
            if (discount.BaseEntity.IsActive == false)
                return false;

            if (discount.Count != null)
                if (discount.Count < 1)
                    return false;

            if (discount.StartDate != null)
                if (discount.StartDate.Value > DateTime.Now)
                    return false;

            if (discount.EndDate != null)
                if (discount.EndDate.Value < DateTime.Now)
                    return false;

            if (discount.Price == null && discount.Percent == null)
                return false;

            return true;
        }

        public static int? GetDiscountedPrice(this Product product)
        {
            Discount? discount;
            discount = product.DiscountProducts
                .Select(a => a.Discount)
                .Where(a => a.IsValid())
                .OrderBy(a => a.Priority)
                .FirstOrDefault(a => true);

            if (discount != null)
                if (discount.IsDiscountValid())
                    return discount.GetDiscountedPrice(product.Price);

            return null;
        }

        public static Discount? GetDiscount(this Product product)
        {
            Discount? discount;
            discount = product.DiscountProducts
                .Select(a => a.Discount)
                .Where(a => a.IsValid())
                .OrderBy(a => a.Priority)
                .FirstOrDefault(a => true);

            if (discount != null)
                return discount;

            return null;
        }

        public static bool HasDiscount(this Product product)
        {
            Discount? discount;
            return product.DiscountProducts
                .Select(a => a.Discount)
                .Where(a => a.IsValid())
                .OrderBy(a => a.Priority)
                .Any();
        }





        //public static string? GetDiscountValue(this Product product)
        //{
        //    Discount? discount;
        //    discount = product.DiscountProducts
        //        .Select(a => a.Discount)
        //        .Where(a => a.IsValid())
        //        .OrderBy(a => a.Priority)
        //        .FirstOrDefault(a => true);

        //    if (discount != null)
        //    {
        //        if (discount.Price != null)
        //            return discount.Price.Value.ToMoney();

        //        if (discount.Percent != null)
        //            return $"{discount.Percent.Value}%";

        //        throw new Exception("Discount is not valid .");
        //    }

        //    return null;
        //}


    }
}
