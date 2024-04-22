using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums.SortTypes;

namespace OrganicShop.Domain.Dtos.CartDtos
{
    public class FilterCartDto : BaseFilterDto<Cart,long>
    {
        public long? UserId { get; set; }
        public CartSortType SortBy { get; set; } = CartSortType.None;

        public IQueryable<Cart> ApplySortType(IQueryable<Cart> query)
        {

            switch (SortBy)
            {
                case CartSortType.None:
                    break;

                case CartSortType.Newest:
                    query = query.OrderByDescending(a => a.Id);
                    break;

                case CartSortType.LatestChange:
                    query = query.OrderByDescending(a => a.BaseEntity.LastModified);
                    break;

                case CartSortType.Oldest:
                    query = query.OrderBy(a => a.Id);
                    break;

                case CartSortType.TotalPrice:
                    query = query.OrderBy(a => a.TotalPrice);
                    break;

                case CartSortType.TotalPriceDesc:
                    query = query.OrderByDescending(a => a.TotalPrice);
                    break;
            }

            return query;
        }


    }





}
