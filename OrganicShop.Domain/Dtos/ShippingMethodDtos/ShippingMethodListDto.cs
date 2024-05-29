using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.ShippingMethodDtos
{
    public class ShippingMethodListDto : BaseListDto<byte>
    {
        public string Type { get; set; }
        public int Price { get; set; }


    }




}
