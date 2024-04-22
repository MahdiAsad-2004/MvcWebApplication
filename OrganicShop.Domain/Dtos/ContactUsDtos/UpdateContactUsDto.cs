using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Dtos.ContactUsDtos
{
    public class UpdateContactUsDto
    {

        [DisplayName("آدرس")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف داشته باشد")]
        public string Address { get; set; }


        [DisplayName("توضیحات کوتاه")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(300, MinimumLength = 2, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف داشته باشد")]
        public string ShortDescription { get; set; }


        [DisplayName("توضیحات")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(5000, MinimumLength = 2, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف داشته باشد")]
        public string Description { get; set; }


        [DisplayName("ایمیل 1")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [EmailAddress(ErrorMessage = "{0} معتبر نیست")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف داشته باشد")]
        public string Email1 { get; set; }


        [DisplayName("ایمیل 2")]
        [EmailAddress(ErrorMessage = "{0} معتبر نیست")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف داشته باشد")]
        public string? Email2 { get; set; }

        [DisplayName("تلفن 1")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0} معتبر نیست")]
        public string Phone1 { get; set; }

        [DisplayName("تلفن 2")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0} معتبر نیست")]
        public string? Phone2 { get; set; }

        [DisplayName("تلفن 3")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0} معتبر نیست")]
        public string? Phone3 { get; set; }


        [DisplayName("تلفن همراه 1")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0} معتبر نیست")]
        public string PhoneNumber1 { get; set; }


        [DisplayName("تلفن همراه 2")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0} معتبر نیست")]
        public string? PhoneNumber2 { get; set; }


        [DisplayName("تلفن همراه 3")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0} معتبر نیست")]
        public string? PhoneNumber3 { get; set; }


        [DisplayName("دفتر 1")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(5000, MinimumLength = 2, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف داشته باشد")]
        public string Office1 { get; set; }

        [DisplayName("دفتر 2")]
        [StringLength(5000, MinimumLength = 2, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف داشته باشد")]
        public string? Office2 { get; set; }


        [DisplayName("ئفتر 3")]
        [StringLength(5000, MinimumLength = 2, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف داشته باشد")]
        public string? Office3 { get; set; }
    }

}
