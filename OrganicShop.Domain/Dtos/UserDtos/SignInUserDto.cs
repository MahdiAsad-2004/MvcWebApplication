using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace OrganicShop.Domain.Dtos.UserDtos
{
    public class SignInUserDto : BaseDto
    {
        [DisplayName("شماره همراه یا ایمیل")]
        [Required(ErrorMessage = "{0} ضروری است")]
        public string PhoneNumberOrEmail { get; set; }


        [DisplayName("رمز عبور")]
        [Required(ErrorMessage = "{0} ضروری است")]
        public string Password { get; set; }


        [DisplayName("من را به خاطر بسپار")]
        [Required(ErrorMessage = "{0} ضروری است")]
        public bool RememberMe { get; set; }
        


    }


}
