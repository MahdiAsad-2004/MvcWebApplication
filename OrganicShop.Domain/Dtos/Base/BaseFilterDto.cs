using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Enums.SortTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Dtos.Base
{
    public abstract class BaseFilterDto<Entity,Key> : BaseDto  where Entity : EntityId<Key> where Key : struct
    {
        //public DeleteFilter DeleteFilter { get; set; } = DeleteFilter.NotDeleted;
        public IsActiveFilter ActiveFilter { get; set; } = IsActiveFilter.Active;


        public IQueryable<Entity> ApplyBaseFilters(IQueryable<Entity> query)
        {
            switch (ActiveFilter)
            {
                case IsActiveFilter.All:
                    break;

                case IsActiveFilter.Active:
                    query = query.Where(a => a.BaseEntity.IsActive == true);
                    break;

                case IsActiveFilter.NotActive:
                    query = query.Where(a => a.BaseEntity.IsActive == false);
                    break;
            }

            return query;
        }


        public IQueryable<Entity> ApplySortType(BaseSortType sortType,IQueryable<Entity> query)
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

                //case BaseSortType.LatestDelete:
                //    query = query.OrderByDescending(a => a.BaseEntity.DeleteDate);
                //    break;
            }

            return query;
        }

    }
}
