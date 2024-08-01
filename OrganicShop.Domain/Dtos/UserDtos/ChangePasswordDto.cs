using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.UserDtos
{
    public class ChangePasswordDto : BaseDto
    {
        public long UserId { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordRepeat { get; set; }
    }





}
