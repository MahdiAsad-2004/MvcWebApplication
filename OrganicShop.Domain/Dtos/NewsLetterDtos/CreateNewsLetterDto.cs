using OrganicShop.Domain.Dtos.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using OrganicShop.Domain.Validation.Attributes;

namespace OrganicShop.Domain.Dtos.NewsLetterDtos
{
    public class CreateNewsLetterDto : BaseDto
    {
        [DisplayName("عنوان")]
        [Required(ErrorMessage = "{0} ضروری است")]
        public string Title { get; set; }


        [DisplayName("محتوا")]
        [StringLength(500, MinimumLength = 2, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف داشته باشد")]
        public string Content { get; set; }


        [DisplayName("تاریخ ارسال")]
        [MinDateNowShamsi()]
        public DateTime SendDate { get; set; }


        [DisplayName("وضعیت")]
        [Required(ErrorMessage = "{0} ضروری است")]
        public bool IsActive { get; set; }
    }





}
