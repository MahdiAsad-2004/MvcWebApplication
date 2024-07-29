using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Entities.Relations;

namespace OrganicShop.DAL.SeedDatas
{
    public static class CouponSeed
    {

        public static readonly Coupon coupon = new Coupon
        {
            Title = "",
            BaseEntity = new BaseEntity(true),
            Code = "",
        };



        public static List<Coupon> GenerateCoupons(int couponsCount)
        {
            List<Coupon> coupons = new List<Coupon>();
            Coupon? coupon = null;
            bool isForCategory = false;
            bool isPercent = false;
            bool hasCount = false;
            bool hasStartDate = false;
            bool hasEndDate = false;
            bool hasMinCost = false;
            bool hasMaxCost = false;
            bool isFreeDelivery = false;

            for (int i = 1; i <= couponsCount; i++)
            {
                isForCategory = Random.Shared.Next(1, 7) >= 5;
                isPercent = Random.Shared.Next(1, 4) >= 2;
                hasCount = Random.Shared.Next(1, 6) >= 3;
                hasStartDate = Random.Shared.Next(1, 6) >= 3;
                hasEndDate = Random.Shared.Next(1, 6) >= 3;
                hasMinCost = Random.Shared.Next(1, 6) >= 3;
                hasMaxCost = Random.Shared.Next(1, 6) >= 3;
                isFreeDelivery = Random.Shared.Next(1, 6) == 5;
                HashSet<int> categoryIds = new HashSet<int>();

                coupon = new Coupon
                {
                    BaseEntity = new BaseEntity(true),
                    Code = Guid.NewGuid().ToString().Substring(0, 6),
                    Title = "Coupon",
                };

                if (isFreeDelivery)
                {
                    coupon.Title = $"{coupon.Title}-FreeDelivery";
                    coupons.Add(coupon);
                    continue;
                }

                if (isPercent)
                {
                    coupon.Percent = Random.Shared.Next(1, 80);
                    coupon.Title = $"{coupon.Title}-Percent:{coupon.Percent}";
                }
                else
                {
                    coupon.Price = ProductSeed.RoundToHundred(Random.Shared.Next(1_000, 10_000));
                    coupon.Title = $"{coupon.Title}-Price:{coupon.Price}";
                }



                if (hasCount)
                {
                    coupon.Count = Random.Shared.Next(0, 11);
                    coupon.UsedCount = Random.Shared.Next(0, coupon.Count.Value);
                    coupon.Title = $"{coupon.Title}-Count:{coupon.Count}";
                }
                else
                {
                    coupon.UsedCount = Random.Shared.Next(0, 11);
                    coupon.Title = $"{coupon.Title}-NoCount";
                }

                if (hasStartDate)
                {
                    coupon.StartDate = DateTime.Now.AddHours(Random.Shared.Next(-72, 72));
                    coupon.Title = $"{coupon.Title}-StartDate:{coupon.StartDate.Value.ToShortDateString()}";
                }
                else
                {
                    coupon.Title = $"{coupon.Title}-NoStartDate";
                }

                if (hasEndDate)
                {
                    if (coupon.StartDate != null)
                    {
                        coupon.EndDate = coupon.StartDate.Value.AddHours(Random.Shared.Next(1, 72));
                    }
                    else
                    {
                        coupon.EndDate = DateTime.Now.AddHours(Random.Shared.Next(-10, 72));
                    }
                    coupon.Title = $"{coupon.Title}-EndDate:{coupon.EndDate.Value.ToShortDateString()}";
                }
                else
                {
                    coupon.Title = $"{coupon.Title}-NoENdDate";
                }

                if (hasMinCost)
                {
                    coupon.MinCost = ProductSeed.RoundToThousand(Random.Shared.Next(50_000, 5_000_000));
                    coupon.Title = $"{coupon.Title}-MinCost:{coupon.MinCost.Value}";
                }
                else
                {
                    coupon.Title = $"{coupon.Title}-NoMinCost";
                }

                if (hasMaxCost)
                {
                    if (coupon.MinCost != null)
                    {
                        coupon.MaxCost = ProductSeed.RoundToThousand(Random.Shared.Next(coupon.MinCost.Value + 100_000, 6_000_000));
                    }
                    else
                    {
                        coupon.MaxCost = Random.Shared.Next(50_000, 5_000_000);
                    }
                    coupon.Title = $"{coupon.Title}-MaxCost:{coupon.MaxCost.Value}";
                }
                else
                {
                    coupon.Title = $"{coupon.Title}-NoMaxCost";
                }

                if (isForCategory)
                {
                    if(Random.Shared.Next(1 , 4) == 1)
                    {
                        coupon.CouponCategories = new List<CouponCategories>();
                        for (int j = 1; j <= Random.Shared.Next(1,4) ; j++)
                        {
                            categoryIds.Add(Random.Shared.Next(1, CategorySeed.Categories_Product.Count + 1));
                        }
                        foreach (var categoryId in categoryIds)
                        {
                            coupon.CouponCategories.Add(new CouponCategories
                            {
                                BaseEntity = new BaseEntity(true),
                                CategoryId = categoryId,
                            });
                        }
                    }
                    else
                    {
                        coupon.CouponCategories = new List<CouponCategories>
                        {
                            new CouponCategories
                            {
                                BaseEntity = new BaseEntity(true),
                                CategoryId = Random.Shared.Next(1, CategorySeed.Categories_Product.Count + 1),
                            }
                        };
                    }
                }

                coupons.Add(coupon);
            }

            return coupons;
        }




















    }
}
