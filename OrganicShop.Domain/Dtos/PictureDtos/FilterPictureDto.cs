using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums.SortTypes;

namespace OrganicShop.Domain.Dtos.PictureDtos
{
    public class FilterPictureDto : BaseFilterDto<Picture, long>
    {
        public string? Name { get; set; }
        public float? MinSize { get; set; }
        public float? MaxSize { get; set; }
        public PictureSortType SortBy { get; set; } = PictureSortType.None;



        public IQueryable<Picture> ApplySortType(IQueryable<Picture> query)
        {

            switch (SortBy)
            {
                case PictureSortType.None:
                    break;

                case PictureSortType.Newest:
                    query = query.OrderByDescending(a => a.Id);
                    break;

                case PictureSortType.LatestChange:
                    query = query.OrderByDescending(a => a.BaseEntity.LastModified);
                    break;

                case PictureSortType.Oldest:
                    query = query.OrderBy(a => a.Id);
                    break;

                case PictureSortType.Size:
                    query = query.OrderBy(a => a.SizeMB);
                    break;

                case PictureSortType.SizeDesc:
                    query = query.OrderByDescending(a => a.SizeMB);
                    break;


            }

            return query;
        }
    }





}
