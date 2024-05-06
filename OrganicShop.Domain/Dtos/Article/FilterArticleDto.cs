using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.SortTypes;

namespace OrganicShop.Domain.Dtos.ArticleDtos
{
    public class FilterArticleDto : BaseFilterDto<Article, int>
    {
        public string? Title { get; set; }
        public string? AuthorName { get; set; }
        public DateTime? MinCreateDate { get; set; }
        public int? CategoryId { get; set; }
        public long? UserId { get; set; }


        public BaseSortType SortBy { get; set; } = BaseSortType.None;

    }




}
