using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Enums.SortTypes;

namespace OrganicShop.Domain.Dtos.CommentDtos
{
    public class FilterCommentDto : BaseFilterDto<Entities.Comment, long>
    {
        public CommentStatus? Status { get; set; }
        public long? UserId { get; set; }
        public CommentSortType SortBy { get; set;} = CommentSortType.None;



        public IQueryable<Comment> ApplySortType(IQueryable<Comment> query)
        {

            switch (SortBy)
            {
                case CommentSortType.None:
                    break;

                case CommentSortType.Newest:
                    query = query.OrderByDescending(a => a.Id);
                    break;

                case CommentSortType.LatestChange:
                    query = query.OrderByDescending(a => a.BaseEntity.LastModified);
                    break;

                case CommentSortType.Oldest:
                    query = query.OrderBy(a => a.Id);
                    break;

                case CommentSortType.Rate:
                    query = query.OrderBy(a => a.Rate);
                    break;

                case CommentSortType.RateDesc:
                    query = query.OrderByDescending(a => a.Rate);
                    break;
            }

            return query;
        }


    }




}
