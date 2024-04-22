using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Enums.SortTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Dtos.TrackingStatusDtos
{
    public class FilterTrackingStatusDto : BaseFilterDto<TrackingStatus, long>
    {
        public DoneStatus? DoneStatus { get; set; }
        public BaseSortType SortBy { get; set; }



        public IQueryable<TrackingStatus> ApplySortType(BaseSortType sortType, IQueryable<TrackingStatus> query)
        {

            switch (sortType)
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
