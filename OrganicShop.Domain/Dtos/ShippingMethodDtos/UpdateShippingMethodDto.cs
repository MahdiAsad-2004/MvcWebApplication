using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.ShippingMethodDtos
{
    public class UpdateShippingMethodDto : BaseListDto<byte>
    {
        public int Price { get; set; }


    }




}
