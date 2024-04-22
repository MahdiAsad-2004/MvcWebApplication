using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Enums.SortTypes;


namespace OrganicShop.Domain.Dtos.UserDtos
{
    public class FilterUserDto : BaseFilterDto<User, long>
    {
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public Role? Role { get; set; }
        public string? Email { get; set; }
        public UserSortType SortBy { get; set; } = UserSortType.None;



        public IQueryable<User> ApplySortType(IQueryable<User> query)
        {

            switch (SortBy)
            {
                case UserSortType.None:
                    break;

                case UserSortType.Newest:
                    query = query.OrderByDescending(a => a.Id);
                    break;

                case UserSortType.LatestChange:
                    query = query.OrderByDescending(a => a.BaseEntity.LastModified);
                    break;

                case UserSortType.Oldest:
                    query = query.OrderBy(a => a.Id);
                    break;

                case UserSortType.Name:
                    query = query.OrderBy(a => a.Name);
                    break;

                case UserSortType.NameDesc:
                    query = query.OrderByDescending(a => a.Name);
                    break;

                case UserSortType.Email:
                    query = query.OrderBy(a => a.Email);
                    break;

                case UserSortType.EmailDesc:
                    query = query.OrderByDescending(a => a.Email);
                    break;

                case UserSortType.PhoneNumber:
                    query = query.OrderBy(a => a.PhoneNumber);
                    break;

                case UserSortType.PhoneNumberDesc:
                    query = query.OrderByDescending(a => a.PhoneNumber);
                    break;





            }

            return query;
        }






    }





}
