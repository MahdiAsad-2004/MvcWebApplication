using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums.SortTypes;

namespace OrganicShop.Domain.Dtos.ProductDtos
{
    public class FilterProductDto : BaseFilterDto<Product, long>
    {
        public long? Id { get; set; }
        public long[]? Ids { get; set; }
        public string? Title { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public int? CategoryId { get; set; }
        public int[]? CategoryIds { get; set; }
        public int? TagId { get; set; }
        public byte? Rate { get; set; }
        public ProductSortType SortBy { get; set; } = ProductSortType.None;



        public IQueryable<Product> ApplySortType(IQueryable<Product> query)
        {
            switch (SortBy)
            {
                case ProductSortType.None:
                    break;

                case ProductSortType.Newest:
                    query = query.OrderByDescending(a => a.Id);
                    break;

                case ProductSortType.LatestChange:
                    query = query.OrderByDescending(a => a.BaseEntity.LastModified);
                    break;

                case ProductSortType.Oldest:
                    query = query.OrderBy(a => a.Id);
                    break;

                case ProductSortType.Price:
                    query = query.OrderBy(a => a.Price);
                    break;

                case ProductSortType.PriceDesc:
                    query = query.OrderByDescending(a => a.Price);
                    break;

                case ProductSortType.Stock:
                    query = query.OrderBy(a => a.Stock);
                    break;

                case ProductSortType.StockDesc:
                    query = query.OrderByDescending(a => a.Stock);
                    break;

                case ProductSortType.SoldCount:
                    query = query.OrderBy(a => a.SoldCount);
                    break;

                case ProductSortType.SoldCountDesc:
                    query = query.OrderByDescending(a => a.SoldCount);
                    break;

                case ProductSortType.Discount:
                        query = query.OrderByDescending(a => a.Price - a.DiscountedPrice);
                        break;
                    
                case ProductSortType.DiscountDesc:
                        query = query.OrderBy(a => a.Price - a.DiscountedPrice);
                        break;

                case ProductSortType.Rate:
                    query = query.OrderBy(a => (float)a.Comments.Sum(b => b.Rate) / a.Comments.Count == 0 ? int.MaxValue : a.Comments.Count);
                    break;

                case ProductSortType.RateDesc:
                    query = query.OrderByDescending(a => (float)a.Comments.Sum(b => b.Rate) / a.Comments.Count == 0 ? int.MaxValue : a.Comments.Count);
                    break;
            }

            return query;
        }



    }

    public static class xxx
    {
        public static int? GetDefaultDiscountedPrice1(this Product product)
        {
            Discount? discount;
            discount = product.DiscountProducts.Select(a => a.Discount).OrderByDescending(a => a.BaseEntity.LastModified)
                .FirstOrDefault(a => a.IsDefault == true);

            if (discount != null)
                return discount.GetDiscountedPrice1(product.Price);

            discount = product.Categories.Last().DiscountCategories.Select(a => a.Discount).OrderByDescending(a => a.BaseEntity.LastModified)
                .FirstOrDefault(a => a.IsDefault == true);

            if (discount != null)
                return discount.GetDiscountedPrice1(product.Price);

            return null;
        }

        public static int GetDiscountedPrice1(this Discount discount, int price)
        {
            if (discount.IsFixDiscount)
            {
                if (discount.FixValue != null)
                    return price - discount.FixValue.Value;
                throw new Exception("Discount is not valid .");
            }
            else
            {
                if (discount.Percent != null)
                    return price - (price * discount.Percent.Value / 100);
                throw new Exception("Discount is not valid .");
            }
        }
    }


}
