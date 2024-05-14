using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OrganicShop.Domain.Dtos.CommentDtos
{
    public class CreateCommentDto : BaseDto
    {   
        [DisplayName("متن دیدگاه")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف داشته باشد")]
        public string Text { get; set; }


        [DisplayName("پاسخ به دیدگاه")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} باشد")]
        public long? ParentId { get; set; }
        
        
        [DisplayName("ایمیل")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف داشته باشد")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "{0} معتبر وارد شده معتبر نیست")]
        public string Email { get; set; }


        [DisplayName("نام")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف داشته باشد")]
        public string AuthorName { get; set; }
        
        
        [DisplayName("دخیره نام و ایمیل")]
        [Required(ErrorMessage = "{0} ضروری است")]
        public bool SaveNameAndEmail { get; set; }
        
        
    }




}
