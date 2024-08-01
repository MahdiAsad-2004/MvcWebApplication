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
        public PersianDateTime? BirthDate { get; set; }
        public string Email { get; set; }


        public string PhoneNumber { get; init; }
        public bool IsEmailVerified { get; init; }
        public PersianDateTime RegisterDate { get; init; }


    }





}
