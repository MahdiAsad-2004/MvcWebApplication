using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Enums.SortTypes;

namespace OrganicShop.Domain.Dtos.NotificationDtos
{
    public class FilterNotificationDto : BaseFilterDto<Notification, int>
    {
        public string? Text { get; set; }
        public BaseSortType SortBy { get; set; } = BaseSortType.None;



        public IQueryable<Notification> ApplySortType(IQueryable<Notification> query)
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




