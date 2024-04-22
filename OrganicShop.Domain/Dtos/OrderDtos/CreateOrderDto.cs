using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.OrderDtos
{
    public class CreateOrderDto : BaseDto
    {
        public DeliveryType DeliveryType { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public long UserId { get; set; }
        public long AddressId { get; set; }
        public long CartId { get; set; }
    }




}
