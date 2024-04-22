using OrganicShop.Domain.Dtos.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OrganicShop.Domain.Dtos.PropertyDtos
{
    public class CreatePropertyDto : BaseDto
    {
        [DisplayName("عنوان")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(30,MinimumLength = 2 , ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف داشته باشد")]
        public string Title { get; set; }


        [DisplayName("الویت")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [Range(1,10,ErrorMessage = " است {2} و حداکثر {1} , {0} حداقل مقدار")]
        public int Priority { get; set; }

    }



}
