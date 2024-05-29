using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.OrderDtos
{
    public class UpdateOrderDto : BaseListDto<long>
    {
        public OrderStatus OrderStatus { get; set; }
        public DateTime DeliveryDateEstimated { get; set; }

    }




}
