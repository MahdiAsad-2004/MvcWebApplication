using OrganicShop.Domain.Dtos.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OrganicShop.Domain.Dtos.WishItemDtos
{
    public class CreateWishItemDto : BaseDto
    {
        [DisplayName("محصول")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [Range(0, long.MaxValue, ErrorMessage = "محصول معتبر نیست")]
        public long ProductId { get; set; }


    }





}
