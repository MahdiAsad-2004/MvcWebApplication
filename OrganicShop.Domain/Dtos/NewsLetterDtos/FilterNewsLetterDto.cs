using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.SortTypes;

namespace OrganicShop.Domain.Dtos.NewsLetterDtos
{
    public class FilterNewsLetterDto : BaseFilterDto<NewsLetter, int>
    {
        public string? Title { get; set; }
        public BaseSortType SortBy { get; set; } = BaseSortType.None;



        public IQueryable<NewsLetter> ApplySortType(IQueryable<NewsLetter> query)
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
