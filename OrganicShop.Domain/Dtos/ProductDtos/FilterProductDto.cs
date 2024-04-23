using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums.SortTypes;

namespace OrganicShop.Domain.Dtos.ProductDtos
{
    public class FilterProductDto : BaseFilterDto<Product, long>
    {
        public string? Title { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public long? ProductId { get; set; }
        public int? CategoryId { get; set; }
        public int? TagId { get; set; }
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
                    {
                        var discountProducts = query.SelectMany(a => a.DiscountProducts);
                        if (query.Select(a => a.Category) != null)
                        {
                            var discountCategories = query.Select(a => a.Category);
                            if (discountProducts != null && discountCategories != null)
                            {
                                query = query.OrderBy(a => a.GetDefaultDiscountedPrice1());
                            }
                        }
                        return query;
                    };

                case ProductSortType.DiscountDesc:
                    {
                        var discountProducts = query.SelectMany(a => a.DiscountProducts);
                        if (query.Select(a => a.Category) != null)
                        {
                            var discountCategories = query.Select(a => a.Category);
                            if (discountProducts != null && discountCategories != null)
                            {
                                query = query.OrderByDescending(a => a.GetDefaultDiscountedPrice1());
                            }
                        }
                        return query;
                    };

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

            discount = product.Category.DiscountCategories.Select(a => a.Discount).OrderByDescending(a => a.BaseEntity.LastModified)
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
