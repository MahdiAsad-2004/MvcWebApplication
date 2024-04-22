using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.OrderDtos
{
    public class OrderListDto : BaseListDto<long>
    {
        public int TotalPrice { get; set; }
        public string UserName { get; set; }
        public string UserPhoneNumber { get; set; }
        public DateTime DeliveryDatePredicate { get; set; }
        public string TrackingCode { get; set; }
        public DeliveryType DeliveryType { get; set; }
        public OrderStatus OrderStatus { get; set; }
       
    }




}
