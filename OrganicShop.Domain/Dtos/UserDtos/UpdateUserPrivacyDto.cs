using MD.PersianDateTime;
using Microsoft.AspNetCore.Http;
using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.UserDtos
{
    public class UpdateUserPrivacyDto : BaseDto
    {
        public long UserId { get; set; }
        public bool IsProfileImageVisible { get; set; }
        public bool IsEmailVisible { get; set; }
        public bool DeleteAccountAfterLogOut { get; set; }


    }





}
