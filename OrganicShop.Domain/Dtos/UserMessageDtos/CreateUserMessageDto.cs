using OrganicShop.Domain.Dtos.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OrganicShop.Domain.Dtos.UserMessageDtos
{
    public class CreateUserMessageDto : BaseDto
    {
        [DisplayName("متن پیام")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف داشته باشد")]
        public string Text { get; set; }


        [DisplayName("نام")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف داشته باشد")]
        public string FirstName { get; set; }


        [DisplayName("نام خانوادگی")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف داشته باشد")]
        public string LastName { get; set; }


        [DisplayName("شماره تماس")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0} معتبر نیست")]
        public string PhoneNumber { get; set; }


        [DisplayName("ایمیل")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف داشته باشد")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "{0} معتبر وارد شده معتبر نیست")]
        public string Email { get; set; }


        [DisplayName("کاربر")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [Range( 1, long.MaxValue ,  ErrorMessage = "{0} معتبر نیست")]

        public long UserId { get; set; }




    }




}
