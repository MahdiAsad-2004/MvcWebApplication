using OrganicShop.Domain.Dtos.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OrganicShop.Domain.Dtos.NotificationDtos
{
    public class CreateNotificationDto : BaseDto
    {
        [DisplayName("متن")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف داشته باشد")]
        public string TextHtml { get; set; }

    }





}
