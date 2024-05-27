using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.DeliveryDtos
{
    public class UpdateDeliveryDto : BaseListDto<byte>
    {
        public int Price { get; set; }


    }




}
