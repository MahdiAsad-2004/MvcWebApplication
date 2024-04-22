using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Enums.SortTypes;

namespace OrganicShop.Domain.Dtos.CategoryDtos
{
    public class FilterCategoryDto : BaseFilterDto<Category, int>
    {
        public string? Title { get; set; }
        public int? ParentId { get; set; }
        public CategoryType Type { get; set; } = CategoryType.All;
        public CategorySortType SortBy { get; set; } = CategorySortType.None;



        public IQueryable<Category> ApplySortType(IQueryable<Category> query)
        {

            switch (SortBy)
            {
                case CategorySortType.None:
                    break;

                case CategorySortType.Newest:
                    query = query.OrderByDescending(a => a.Id);
                    break;

                case CategorySortType.LatestChange:
                    query = query.OrderByDescending(a => a.BaseEntity.LastModified);
                    break;

                case CategorySortType.Oldest:
                    query = query.OrderBy(a => a.Id);
                    break;

                case CategorySortType.Title:
                    query = query.OrderBy(a => a.Title);
                    break;

                case CategorySortType.TitleDesc:
                    query = query.OrderByDescending(a => a.Title);
                    break;
            }

            return query;
        }


    }




}
