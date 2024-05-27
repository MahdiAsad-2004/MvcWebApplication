using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums.SortTypes;

namespace OrganicShop.Domain.Dtos.UserMessageDtos
{
    public class FilterUserMessageDto : BaseFilterDto<UserMessage, int>
    {
        public string? Text { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? UserName { get; set; }
        public long? UserId { get; set; }

        public BaseSortType SortBy { get; set; } = BaseSortType.None;



        public IQueryable<UserMessage> ApplySortType(IQueryable<UserMessage> query)
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
