using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Entities.ComplexTypes;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Entities
{
    [DisplayName("سفارش")]
    public class Order : EntityId<long>
    {
        public string TrackingCode { get; set; }
        public int TotalPrice { get; set; }
        public int CouponAmount { get; set; }
        public int FinalPrice { get; set; }
        public int ShippingPrice { get; set; }
        public string ShippingMethodName { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime DeliveryDateEstimated { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public OrderAddress OrderAddress { get; set; }
        public long UserId { get; set; }




        public User Receiver { get; set; }
        public ICollection<TrackingStatus> TrackingStatuses { get; set; }
        public ICollection<TrackingDescription> TrackingDescriptions { get; set; }
        public ICollection<ProductItem> ProductItems { get; set; }


    }


}
