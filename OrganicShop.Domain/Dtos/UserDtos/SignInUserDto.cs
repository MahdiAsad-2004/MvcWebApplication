using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace OrganicShop.Domain.Dtos.UserDtos
{
    public class SignInUserDto : BaseDto
    {
        [DisplayName("شماره همراه")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0} معتبر نیست")]
        public string PhoneNumber { get; set; }


        [DisplayName("رمز عبور")]
        [Required(ErrorMessage = "{0} ضروری است")]
        public string Password { get; set; }


        [DisplayName("من را به خاطر بسپار")]
        [Required(ErrorMessage = "{0} ضروری است")]
        public bool RememberMe { get; set; }
        


    }


}
