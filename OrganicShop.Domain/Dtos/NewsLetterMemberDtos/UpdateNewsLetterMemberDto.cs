using OrganicShop.Domain.Dtos.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OrganicShop.Domain.Dtos.NewsLetterMemberDtos
{
    public class UpdateNewsLetterMemberDto : BaseListDto<int>
    {

        [DisplayName("وضعیت عضویت")]
        [Required(ErrorMessage = "{0} ضروری است")]
        public bool IsActive { get; set; }

    }





}
