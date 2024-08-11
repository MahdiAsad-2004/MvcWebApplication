using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums.SortTypes;

namespace OrganicShop.Domain.Dtos.CouponDtos
{
    public class FilterCouponDto : BaseFilterDto<Coupon,int>
    {
        public long? UserId { get; set; }
        public bool? IsFixCoupon { get; set; }
        public CouponSortType SortBy { get; set; } = CouponSortType.None;



        public IQueryable<Coupon> ApplySortType(IQueryable<Coupon> query)
        {

            switch (SortBy)
            {
                case CouponSortType.None:
                    break;

                case CouponSortType.Newest:
                    query = query.OrderByDescending(a => a.Id);
                    break;

                case CouponSortType.LatestChange:
                    query = query.OrderByDescending(a => a.BaseEntity.LastModified);
                    break;

                case CouponSortType.Oldest:
                    query = query.OrderBy(a => a.Id);
                    break;

                case CouponSortType.Percent:
                    query = query.OrderBy(a => a.Percent);
                    break;

                case CouponSortType.PercentDesc:
                    query = query.OrderByDescending(a => a.Percent);
                    break;

                case CouponSortType.FixedValue:
                    query = query.OrderBy(a => a.Price);
                    break;

                case CouponSortType.FixedValueDesc:
                    query = query.OrderByDescending(a => a.Price);
                    break;

                case CouponSortType.Count:
                    query = query.OrderBy(a => a.Count);
                    break;

                case CouponSortType.CountDesc:
                    query = query.OrderByDescending(a => a.Count);
                    break;


            }

            return query;
        }

    }



}
