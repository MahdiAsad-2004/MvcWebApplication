using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.SortTypes;

namespace OrganicShop.Domain.Dtos.TrackingDescriptionDtos
{
    public class FilterTrackingDescriptionDto : BaseFilterDto<TrackingDescription, long>
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long? OrderId { get; set; }
        public TrackingDescriptionSortType SortBy { get; set; } = TrackingDescriptionSortType.None;



        public IQueryable<TrackingDescription> ApplySortType(IQueryable<TrackingDescription> query)
        {

            switch (SortBy)
            {
                case TrackingDescriptionSortType.None:
                    break;

                case TrackingDescriptionSortType.Newest:
                    query = query.OrderByDescending(a => a.Id);
                    break;

                case TrackingDescriptionSortType.LatestChange:
                    query = query.OrderByDescending(a => a.BaseEntity.LastModified);
                    break;

                case TrackingDescriptionSortType.Oldest:
                    query = query.OrderBy(a => a.Id);
                    break;

                case TrackingDescriptionSortType.Title:
                    query = query.OrderBy(a => a.Title);
                    break;

                case TrackingDescriptionSortType.TitleDesc:
                    query = query.OrderByDescending(a => a.Title);
                    break;
            }

            return query;
        }

    }





}
