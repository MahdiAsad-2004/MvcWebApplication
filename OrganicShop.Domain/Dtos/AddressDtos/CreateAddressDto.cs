using OrganicShop.Domain.Dtos.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.AddressDtos
{
    public class CreateAddressDto : BaseDto
    {
        [DisplayName("عنوان")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف داشته باشد")]
        public string Title { get; set; }


        [DisplayName("نام و نام خانوادگی")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف داشته باشد")]
        public string ReceiverName { get; set; }


        [DisplayName("آدرس")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف داشته باشد")]
        public string Text { get; set; }


        [DisplayName("کد پستی")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "{0} معتبر نیست")]
        public string PostCode { get; set; }


        [DisplayName("شماره همراه")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0} معتبر نیست")]
        public string PhoneNumber { get; set; }


        [DisplayName("استان")]
        [Required(ErrorMessage = "{0} ضروری است")]
        public Province Province { get; set; }


        [DisplayName("کاربر")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [Range(1, long.MaxValue, ErrorMessage = "{0} معتبر نیست")]
        public long UserId { get; set; }
    
    
    
    
    
    
    }


}
