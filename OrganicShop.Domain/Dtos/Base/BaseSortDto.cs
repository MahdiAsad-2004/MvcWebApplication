using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums.SortTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Dtos.Base
{
    public class BaseSortDto<Entity, key> : BaseDto where Entity : EntityId<key> where key : struct
    {
        public BaseSortType BaseSortType { get; set; } = BaseSortType.None;




        public IQueryable<Entity> ApplyBaseSort(IQueryable<Entity> query)
        {

            switch (BaseSortType)
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
