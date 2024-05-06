using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.ValidationsAttributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OrganicShop.Domain.Dtos.DiscountDtos
{
    public class CreateDiscountDto : BaseDto
     {
        [DisplayName("عنوان")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف داشته باشد")]
        public string Title { get; set; }

        [DisplayName("اعمال پیشفرض")]
        [Required(ErrorMessage = "{0} ضروری است")]
        public bool IsDefault { get; set; }

        [DisplayName("نوع نخفیف")]
        [Required(ErrorMessage = "{0} ضروری است")]
        public bool IsFixDiscount { get; set; }

        [DisplayName("کد")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف باشد")]
        public string? Code { get; set; }

        [DisplayName("تعداد")]
        [Range(1,1000,ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} باشد")]
        public int? Count { get; set; }

        [DisplayName("مقدار تخفیف ثابت")]
        [Range(1000, 10_000_000, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} باشد")]
        [Required(ErrorMessage = "{0} ضروری است")]
        public int FixValue { get; set; }

        [DisplayName("درصد تخفیف")]
        [Range(1, 100, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} باشد")]
        [Required(ErrorMessage = "{0} ضروری است")]
        public int Percent { get; set; }

        [DisplayName("تاریخ شروع")]
        [MinDateNowShamsi]
        [Indicator]
        public DateTime? StartDate { get; set; }
        
        [DisplayName("تاریخ پایان")]
        [GreaterThan(nameof(StartDate), "تاریخ شروع" , "بعد")]
        [DataType(DataType.DateTime,ErrorMessage = "{0} معتبر نیست ")]
        public DateTime? EndDate { get; set; }


        [DisplayName("فعال سازی")]
        [Required(ErrorMessage = "{0} ضروری است")]
        public bool IsActive { get; set; }


        [DisplayName("ارسال رایگان")]
        [Required(ErrorMessage = "{0} ضروری است")]
        public bool FreeDelivery { get; set; }


        [DisplayName("حداقل هزینه")]
        [Range(1000,10_000_000,ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} باشد")]
        [Indicator]
        public int? MinCost { get; set; }


        [DisplayName("حداکثر هزینه")]
        [Range(1000,10_000_000,ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} باشد")]
        [GreaterThan(nameof(MinCost), "حداقل هزینه")]
        public int? MaxCost { get; set; }


        [DisplayName("الویت")]
        [Range(1, 100, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} باشد")]
        public int Priority { get; set; }


        [DisplayName("دسته ها")]
        public int[] CategoryIds { get; set; }


        [DisplayName("محصولات")]
        public long[] ProductIds { get; set; }

    }



}
