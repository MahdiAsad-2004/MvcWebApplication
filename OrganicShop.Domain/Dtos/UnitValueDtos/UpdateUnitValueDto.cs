using OrganicShop.Domain.Dtos.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.UnitValueDtos
{
    public class UpdateUnitValueDto : BaseListDto<long>
    {
        [DisplayName("واحد")]
        [Required(ErrorMessage = "{0} ضروری است")]
        public UnitType UnitType { get; set; }


        [DisplayName("مقدار")]
        [Required(ErrorMessage = "{0} ضروری است")]
        public float Value { get; set; }
    }





}
