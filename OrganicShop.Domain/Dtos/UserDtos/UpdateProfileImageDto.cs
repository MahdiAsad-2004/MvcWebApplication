using MD.PersianDateTime;
using Microsoft.AspNetCore.Http;
using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.UserDtos
{
    public class UpdateProfileImageDto : BaseDto
    {
        public long UserId { get; set; }
        public IFormFile ImageFile { get; set; }


    }





}
