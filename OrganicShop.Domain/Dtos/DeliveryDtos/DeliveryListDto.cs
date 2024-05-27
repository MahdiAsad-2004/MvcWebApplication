using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.DeliveryDtos
{
    public class DeliveryListDto : BaseListDto<byte>
    {
        public string Type { get; set; }
        public int Price { get; set; }

 
    }




}
