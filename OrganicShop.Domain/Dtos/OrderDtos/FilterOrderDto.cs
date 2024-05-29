using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Enums.SortTypes;

namespace OrganicShop.Domain.Dtos.OrderDtos
{
    public class FilterOrderDto : BaseFilterDto<Order, long>
    {
        public long UserId { get; set; }
        public OrderStatus? OrderStatus { get; set; }
        public string ShippingMethodName { get; set; }
        public string? UserPhoneNumber { get; set; }
        public string? TrackingCode { get; set; }
        public OrderSortType SortBy { get; set; } = OrderSortType.None;


        public IQueryable<Order> ApplySortType(IQueryable<Order> query)
        {

            switch (SortBy)
            {
                case OrderSortType.None:
                    break;

                case OrderSortType.Newest:
                    query = query.OrderByDescending(a => a.Id);
                    break;

                case OrderSortType.LatestChange:
                    query = query.OrderByDescending(a => a.BaseEntity.LastModified);
                    break;

                case OrderSortType.Oldest:
                    query = query.OrderBy(a => a.Id);
                    break;

                case OrderSortType.TotalPrice:
                    query = query.OrderBy(a => a.TotalPrice);
                    break;

                case OrderSortType.TotalPriceDesc:
                    query = query.OrderByDescending(a => a.TotalPrice);
                    break;
            }

            return query;
        }
    }




}
