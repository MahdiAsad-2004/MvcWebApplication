using OrganicShop.Domain.Dtos.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OrganicShop.Domain.Dtos.SellerDtos
{
    public class UpdateSellerDto : BaseListDto<int>
    {
        [DisplayName("عنوان")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف داشته باشد")]
        public string Title { get; set; }


        [DisplayName("وضعیت")]
        [Required(ErrorMessage = "{0} ضروری است")]
        public bool IsActive { get; set; }
    }





}
