using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums.SortTypes;

namespace OrganicShop.Domain.Dtos.PermissionDtos
{
    public class FilterPermissionDto : BaseFilterDto<Entities.Permission, byte>
    {
        public byte? ParentId { get; set; }
        public long? UserId { get; set; }
        public PermissionSortType SortBy { get; set; }


        public IQueryable<Permission> ApplySortType(IQueryable<Permission> query)
        {

            switch (SortBy)
            {
                case PermissionSortType.None:
                    break;

                case PermissionSortType.Newest:
                    query = query.OrderByDescending(a => a.Id);
                    break;

                case PermissionSortType.LatestChange:
                    query = query.OrderByDescending(a => a.BaseEntity.LastModified);
                    break;

                case PermissionSortType.Oldest:
                    query = query.OrderBy(a => a.Id);
                    break;

                case PermissionSortType.Title:
                    query = query.OrderBy(a => a.Title);
                    break;

                case PermissionSortType.TitleDesc:
                    query = query.OrderByDescending(a => a.Title);
                    break;

                case PermissionSortType.EnTitle:
                    query = query.OrderBy(a => a.EnTitle);
                    break;

                case PermissionSortType.EnTitleDesc:
                    query = query.OrderByDescending(a => a.EnTitle);
                    break;

            }

            return query;
        }
    }


}
