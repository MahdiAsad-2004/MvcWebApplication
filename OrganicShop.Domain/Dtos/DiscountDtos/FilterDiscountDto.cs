using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums.SortTypes;

namespace OrganicShop.Domain.Dtos.DiscountDtos
{
    public class FilterDiscountDto : BaseFilterDto<Discount,int>
    {
        public long? UserId { get; set; }
        public long? ProductId { get; set; }
        public bool? IsFixDiscount { get; set; }
        public DiscountSortType SortBy { get; set; } = DiscountSortType.None;



        public IQueryable<Discount> ApplySortType(IQueryable<Discount> query)
        {

            switch (SortBy)
            {
                case DiscountSortType.None:
                    break;

                case DiscountSortType.Newest:
                    query = query.OrderByDescending(a => a.Id);
                    break;

                case DiscountSortType.LatestChange:
                    query = query.OrderByDescending(a => a.BaseEntity.LastModified);
                    break;

                case DiscountSortType.Oldest:
                    query = query.OrderBy(a => a.Id);
                    break;

                case DiscountSortType.Percent:
                    query = query.OrderBy(a => a.Percent);
                    break;

                case DiscountSortType.PercentDesc:
                    query = query.OrderByDescending(a => a.Percent);
                    break;

                case DiscountSortType.FixedValue:
                    query = query.OrderBy(a => a.Price);
                    break;

                case DiscountSortType.FixedValueDesc:
                    query = query.OrderByDescending(a => a.Price);
                    break;

                case DiscountSortType.Count:
                    query = query.OrderBy(a => a.Count);
                    break;

                case DiscountSortType.CountDesc:
                    query = query.OrderByDescending(a => a.Count);
                    break;


            }

            return query;
        }

    }



}
