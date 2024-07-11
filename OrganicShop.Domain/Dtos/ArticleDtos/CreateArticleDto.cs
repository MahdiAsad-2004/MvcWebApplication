using MD.PersianDateTime;
using Microsoft.AspNetCore.Http;
using OrganicShop.Domain.Dtos.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using OrganicShop.Domain.Validation.Attributes;

namespace OrganicShop.Domain.Dtos.ArticleDtos
{
    public class CreateArticleDto : BaseDto
    {
        [DisplayName("عنوان")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف داشته باشد")]
        public string Title { get; set; }


        [DisplayName("عنوان")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(10_000, MinimumLength = 2, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف داشته باشد")]
        public string Content { get; set; }


        [DisplayName("کاربر")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} معتبر نیست")]
        public int CategoryId { get; set; }

        [DisplayName("کاربر")]
        public int[] TagIds { get; set; }


        [DisplayName("تصویر شاخص")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [FileSize(1_000)]
        [FileFormat(new string[] { "jpg", "png", "jpeg" })]
        public IFormFile MainPictureFile { get; set; }



    }


}
