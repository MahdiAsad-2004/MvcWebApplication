using OrganicShop.Domain.Dtos.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OrganicShop.Domain.Dtos.SellerDtos
{
    public class CreateSellerDto : BaseDto
    {
        [DisplayName("عنوان")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف داشته باشد")]
        [RegularExpression(@"[a-zA-Z0-9|_\- ]*", ErrorMessage = "{0} نمی تواند شامل کاراکتر های خاص باشد")]
        public string Title { get; set; }


        [DisplayName("توضیحات")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(500, MinimumLength = 2, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف داشته باشد")]
        public string Description { get; set; }


        [DisplayName("کاربر")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [Range(0, long.MaxValue, ErrorMessage = "{0} معتبر نیست")]
        public long UserId { get; set; }
    
    
    
    }





}
