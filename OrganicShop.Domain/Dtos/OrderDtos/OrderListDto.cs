using MD.PersianDateTime;
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
        public string ShippingMethodName { get; set; }
        public int ShippingPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PersianDateTime CreateDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }


    }




}
