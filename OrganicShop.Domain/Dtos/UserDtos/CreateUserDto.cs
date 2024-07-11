using Microsoft.AspNetCore.Http;
using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Validation.Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OrganicShop.Domain.Dtos.UserDtos
{
    public class CreateUserDto : BaseDto
    {
        [DisplayName("نام")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف داشته باشد")]
        public string Name { get; set; }

        [DisplayName("رمز عبور")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [MinLength(8, ErrorMessage = "{0} باید حداقل {1} حرف باشد")]
        public string Password { get; set; }

        [DisplayName("تکرار رمز عبور")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [Compare(nameof(Password), ErrorMessage = $"رمز عبور و تکرار آن یکسان نیستند")]
        public string PasswordRepeat { get; set; }

        [DisplayName("شماره همراه")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0} معتبر نیست")]
        public string PhoneNumber { get; set; }

        [DisplayName("ایمیل")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "{0} معتبر نیست")]
        [DuplicateEmail(ErrorMessage = "{0} از قبل وجود دارد")]
        public string Email { get; set; }

        [DisplayName("نقش کاربر")]
        public Role Role { get; set; }

        [DisplayName("تصویر پروفایل")]
        [FileSize(500)]
        [FileFormat(new string[] {"jpg","png","jpeg"})]
        public IFormFile? ProfileImage { get; set; }

        [DisplayName("مجوز ها")]
        public int[] Permissions { get; set; }




      


    }





}
