using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.SortTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Dtos.TagDtos
{
    public class FilterTagDto : BaseFilterDto<Entities.Tag, int>
    {
        public string? Title { get; set; }
        public TagSortType SortBy { get; set; } = TagSortType.None;



        public IQueryable<Tag> ApplySortType(IQueryable<Tag> query)
        {

            switch (SortBy)
            {
                case TagSortType.None:
                    break;

                case TagSortType.Newest:
                    query = query.OrderByDescending(a => a.Id);
                    break;

                case TagSortType.LatestChange:
                    query = query.OrderByDescending(a => a.BaseEntity.LastModified);
                    break;

                case TagSortType.Oldest:
                    query = query.OrderBy(a => a.Id);
                    break;

                case TagSortType.Title:
                    query = query.OrderBy(a => a.Title);
                    break;

                case TagSortType.TitleDesc:
                    query = query.OrderByDescending(a => a.Title);
                    break;
            }

            return query;
        }

    }



}
