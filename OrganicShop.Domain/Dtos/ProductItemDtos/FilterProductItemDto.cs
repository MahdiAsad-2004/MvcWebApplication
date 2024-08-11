using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums.SortTypes;

namespace OrganicShop.Domain.Dtos.ProductItemDtos
{
    public class FilterProductItemDto : BaseFilterDto<Entities.ProductItem, long>
    {
        public long? ProductId { get; set; }
        public long? CartId { get; set; }
        public long? OrderId { get; set; }
        public bool? IsOrdered { get; set; }
        public long? CartUserId { get; set; }
        public ProductItemSortType SortBy { get; set; } = ProductItemSortType.None;


        public IQueryable<ProductItem> ApplySortType(IQueryable<ProductItem> query)
        {

            switch (SortBy)
            {
                case ProductItemSortType.None:
                    break;

                case ProductItemSortType.Newest:
                    query = query.OrderByDescending(a => a.Id);
                    break;

                case ProductItemSortType.LatestChange:
                    query = query.OrderByDescending(a => a.BaseEntity.LastModified);
                    break;

                case ProductItemSortType.Oldest:
                    query = query.OrderBy(a => a.Id);
                    break;

                case ProductItemSortType.PurchasedPrice:
                    query = query.OrderBy(a => a.PurchasedPrice);
                    break;

                case ProductItemSortType.PurchasedPriceDesc:
                    query = query.OrderByDescending(a => a.PurchasedPrice);
                    break;

                case ProductItemSortType.Count:
                    query = query.OrderBy(a => a.Count);
                    break;

                case ProductItemSortType.CountDesc:
                    query = query.OrderByDescending(a => a.Count);
                    break;
            }

            return query;
        }
    }

}
