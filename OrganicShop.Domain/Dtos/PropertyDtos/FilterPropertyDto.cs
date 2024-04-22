using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums.SortTypes;

namespace OrganicShop.Domain.Dtos.PropertyDtos
{
    public class FilterPropertyDto : BaseFilterDto<Entities.Property, int>
    {
        public bool? IsBase { get; set; }
        public long? ProductId { get; set; }
        public BaseSortType SortBy { get; set; } = BaseSortType.None;


        public IQueryable<Property> ApplySortType(BaseSortType sortType, IQueryable<Property> query)
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
