using OrganicShop.Domain.Dtos.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OrganicShop.Domain.Dtos.NewsLetterMemberDtos
{
    public class CreateNewsLetterMemberDto : BaseDto
    {
        [DisplayName("ایمیل")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف داشته باشد")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "{0} معتبر وارد شده معتبر نیست")]
        public string Email { get; set; }

    }





}
