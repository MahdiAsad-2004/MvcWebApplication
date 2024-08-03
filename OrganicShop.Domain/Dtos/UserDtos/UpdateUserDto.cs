using MD.PersianDateTime;
using Microsoft.AspNetCore.Http;
using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.UserDtos
{
    public class UpdateUserDto : BaseListDto<long>
    {
        public string Name { get; set; }
        public Gender? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Email { get; set; }


        /// only using for display data and not for update    

        public string PhoneNumber_readonly { get; init; }
        public bool IsEmailVerified_readonly { get; init; }
        public PersianDateTime RegisterDate_readonly { get; init; }


    }





}
