using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums.SortTypes;

namespace OrganicShop.Domain.Dtos.FaqDtos
{
    public class FilterFaqDto : BaseFilterDto<Faq, byte>
    {
        public string? QuestionText { get; set; }
        public string? AnswerText { get; set; }

        public BaseSortType SortBy { get; set; } = BaseSortType.None;



        public IQueryable<Faq> ApplySortType(IQueryable<Faq> query)
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
