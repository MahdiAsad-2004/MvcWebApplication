using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.UserDtos
{
    public class ChangePasswordDto : BaseListDto<long>
    {
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordRepeat { get; set; }
    }





}
