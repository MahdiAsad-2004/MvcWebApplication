using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OrganicShop.Domain.Dtos.CommentDtos
{
    public class CreateCommentFeedbackUserDto : BaseDto
    {

        [DisplayName("کاربر")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [Range(1, long.MaxValue, ErrorMessage = "{0} معتبر نیست")]
        public long UserId { get; set; }


        [DisplayName("امتیاز")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [Range(1, 5, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} باشد")]
        public int Rate { get; set; }


        [DisplayName("متن دیدگاه")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف داشته باشد")]
        public string Text { get; set; }


        [DisplayName("پاسخ به دیدگاه")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} معتبر نیست")]
        public long? ParentId { get; set; }


        [DisplayName("محصول")]
        [Range(1, long.MaxValue, ErrorMessage = "{0} معتبر نیست")]
        public long? ProductId { get; set; }


        [DisplayName("فروشنده")]
        [Range(1, long.MaxValue, ErrorMessage = "{0} معتبر نیست")]
        public long? SellerId { get; set; }



    }




}
