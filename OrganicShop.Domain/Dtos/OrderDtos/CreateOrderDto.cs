using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using OrganicShop.Domain.Validation.Attributes;
using OrganicShop.Domain.Entities.ComplexTypes;

namespace OrganicShop.Domain.Dtos.OrderDtos
{
    public class CreateOrderDto : BaseDto
    {
        [DisplayName("روش حمل و نقل")]
        [Required(ErrorMessage = "{0} ضروری است")]
        public string ShippingMethodName { get; set; }


        [DisplayName("روش پرداخت")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [Range(1,(int)PaymentMethod.CartToCart, ErrorMessage = "{0} معتبر نیست")]
        public PaymentMethod PaymentMethod { get; set; }


        [DisplayName("تاریخ ارسال")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [PersianDateValidation]
        [MinDateNowShamsi]
        public string SendDate { get; set; }


        [DisplayName("مجموع هزینه محصولات")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [Range(1000, int.MaxValue, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} باشد")]
        public int TotalPrice { get; set; }


        [DisplayName("مقدار کوپن")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [Range(1000, int.MaxValue, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} باشد")]
        public int CouponAmount { get; set; }
        

        [DisplayName("کوپن")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} معتبر نیست")]
        public int CouponId { get; set; }


        [DisplayName("هزینه حمل و نقل")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [Range(1000, int.MaxValue, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} باشد")]
        public int ShippingPrice { get; set; }


        [DisplayName("هزینه نهایی")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [Range(1000, int.MaxValue, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} باشد")]
        public int FinalPrice { get; set; }


        [DisplayName("کاربر")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [Range(1, long.MaxValue, ErrorMessage = "{0} معتبر نیست")]
        public long UserId { get; set; }


        [DisplayName("آدرس")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [Range(1, long.MaxValue, ErrorMessage = "{0} معتبر نیست")]
        public long AddressId { get; set; }


        [DisplayName("سبد خرید")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [Range(1, long.MaxValue, ErrorMessage = "{0} معتبر نیست")]
        public long CartId { get; set; }



        [DisplayName("روش ارسال")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [Range(1, byte.MaxValue, ErrorMessage = "{0} معتبر نیست")]
        public byte ShippingMethodId { get; set; }



        public Dictionary<int, int> DiscountIdAndProductCount { get; set; } = new Dictionary<int, int>();


        public Dictionary<long, int> ProductItemIdAndPrice { get; set; } = new Dictionary<long, int>();


        public OrderStatus OrderStatus { get; set; } = OrderStatus.AwaitingPayment;


    }

}
