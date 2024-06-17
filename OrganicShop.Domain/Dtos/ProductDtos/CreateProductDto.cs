using Microsoft.AspNetCore.Http;
using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Validation.Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OrganicShop.Domain.Dtos.ProductDtos
{
    public class CreateProductDto : BaseDto
    {
        [DisplayName("عنوان")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف داشته باشد")]
        public string Title { get; set; }

        [DisplayName("موجودی")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [Range(0, 10_000, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} باشد")]
        public int Stock { get; set; }

        [DisplayName("قیمت")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [Range(1_000, 100_000_000, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} باشد")]
        [Indicator]
        public int Price { get; set; }

        [DisplayName("توضیحات مختصر")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(500, MinimumLength = 2, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف داشته باشد")]
        public string ShortDescription { get; set; }

        [DisplayName("توضیحات")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(5000, MinimumLength = 1, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف داشته باشد")]
        public string Description { get; set; }

        [DisplayName("قیمت با تخفیف")]
        [Range(1_000, 100_000_000, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} باشد")]
        [LowerThan(nameof(Price),"قیمت")]
        public int? UpdatedPrice { get; set; }

        [DisplayName("تعداد تخفیف")]
        [Range(1, 1_000, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} باشد")]
        public int? DiscountCount { get; set; }

        [DisplayName("دسته بندی")]
        [Required(ErrorMessage = "{0} ضروری است")]
        public int CategoryId { get; set; }

        [DisplayName("تصویر شاخص")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [FileSize(1_000)]
        [FileFormat(new string[] {"png", "jpg", "jpeg"})]
        public IFormFile MainImageFile { get; set; }

        [DisplayName("تصاویر")]
        [FilesCount(0,2)]
        [FileSize(1_000)]
        [FileFormat(new string[] {"png", "jpg", "jpeg"})]
        public IEnumerable<IFormFile>? PictureFiles { get; set; }


        [DisplayName("برچسب ها")]
        public int[]? TagIds { get; set; }


        [DisplayName("ویژگی ها")]
        public Dictionary<int, string>? PropertiesDictionary { get; set; }




        public float[] UnitValuesArray { get; set; }
        //public Dictionary<int,CreateUnitValueDto> UnitValuesDictionary { get; set; }
    }


}
