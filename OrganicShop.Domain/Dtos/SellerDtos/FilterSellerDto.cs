using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.SortTypes;

namespace OrganicShop.Domain.Dtos.SellerDtos
{
    public class FilterSellerDto : BaseFilterDto<Seller, int>
    {
        public string? Title { get; set; }
        public long? UserId { get; set; }
        public BaseSortType SortBy { get; set; } = BaseSortType.None;



        public IQueryable<Seller> ApplySortType(IQueryable<Seller> query)
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
