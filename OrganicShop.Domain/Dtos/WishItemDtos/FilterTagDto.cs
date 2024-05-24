using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Relations;
using OrganicShop.Domain.Enums.SortTypes;

namespace OrganicShop.Domain.Dtos.WishItemDtos
{
    public class FilterWishItemDto : BaseFilterDto<WishItem, long>
    {
        public long? UserId { get; set; }
        public long? ProductId { get; set; }
        public BaseSortType SortBy { get; set; } = BaseSortType.None;



        public IQueryable<WishItem> ApplySortType(IQueryable<WishItem> query)
        {

            switch (SortBy)
            {
                case BaseSortType.None:
                    break;

                case BaseSortType.Newest:
                    query = query.OrderByDescending(a => a.Id);
                    break;

                case BaseSortType.LatestChange:
                    query = query.OrderByDescending(a => a.BaseEntity.LastModified);
                    break;

                case BaseSortType.Oldest:
                    query = query.OrderBy(a => a.Id);
                    break;

            }

            return query;
        }

    }



}
