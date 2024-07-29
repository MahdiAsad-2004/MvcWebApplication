using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;
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
                
                case ProductSortType.Title:
                    query = query.OrderBy(a => a.Title);
                    break;

                case ProductSortType.TitleDesc:
                    query = query.OrderByDescending(a => a.Title);
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
                    query = query.OrderBy(a => a.Price - a.DiscountedPrice);
                    break;

                case ProductSortType.DiscountDesc:
                    query = query.OrderByDescending(a => a.Price - a.DiscountedPrice);
                    break;

                case ProductSortType.Rate:
                    query = query.OrderBy(a => (float)a.Comments.Where(b =>
                        b.Status == CommentStatus.Accepted).Sum(b => b.Rate) /
                        (a.Comments.Count(b => b.Status == CommentStatus.Accepted) == 0 ? float.MaxValue : (float)a.Comments.Count(b => b.Status == CommentStatus.Accepted))
                    );
                    break;

                case ProductSortType.RateDesc:
                    query = query.OrderByDescending(a => (float)a.Comments.Where(b =>
                      b.Status == CommentStatus.Accepted).Sum(b => b.Rate) /
                      (a.Comments.Count(b => b.Status == CommentStatus.Accepted) == 0 ? float.MaxValue : (float)a.Comments.Count(b => b.Status == CommentStatus.Accepted))
                    );

                    //query = query.OrderByDescending(a => (float)a.Comments.Sum(b => b.Rate) / (a.Comments.Count == 0 ? int.MaxValue : a.Comments.Count));
                    break;

                default:
                    throw new Exception();
            }

            return query;
        }



    }


}
