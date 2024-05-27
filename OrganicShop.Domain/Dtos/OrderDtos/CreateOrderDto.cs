using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using OrganicShop.Domain.ValidationsAttributes;

namespace OrganicShop.Domain.Dtos.OrderDtos
{
    public class CreateOrderDto : BaseDto
    {
        [DisplayName("حمل و نقل")]
        [Required(ErrorMessage = "{0} ضروری است")]
        public DeliveryType DeliveryType { get; set; }


        [DisplayName("روش پرداهت")]
        [Required(ErrorMessage = "{0} ضروری است")]
        public PaymentMethod PaymentMethod { get; set; }


        [DisplayName("تاریخ ارسال")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [MinDateNowShamsi]
        public DateTime DeliveryDate { get; set; }


        [DisplayName("مجموع هزینه محصولات")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [Range(1000, int.MaxValue, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} باشد")]
        public int TotalPrice { get; set; }


        [DisplayName("مقدار تخفیف")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [Range(1000, int.MaxValue, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} باشد")]
        public int DiscountPrice { get; set; }


        [DisplayName("هزینه حمل و نقل")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [Range(1000, int.MaxValue, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} باشد")]
        public int DeliveryPrice { get; set; }


        [DisplayName("هزینه نهایی")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [Range(1000, int.MaxValue, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} باشد")]
        public int FinalPrice { get; set; }


        [DisplayName("کاربر")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [Range(0, long.MaxValue, ErrorMessage = "{0} معتبر نیست")]
        public long UserId { get; set; }


        [DisplayName("آدرس")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [Range(0, long.MaxValue, ErrorMessage = "{0} معتبر نیست")]
        public long AddressId { get; set; }


        [DisplayName("سبد خرید")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [Range(0, long.MaxValue, ErrorMessage = "{0} معتبر نیست")]
        public long CartId { get; set; }




    }

}
