using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Entities
{
    [DisplayName("سفارش")]
    public class Order : EntityId<long>
    {
        public string TrackingCode { get; set; }
        public int TotalPrice { get; set; }
        public DeliveryType DeliveryType { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime DeliveryDatePredicate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public long AddressId { get; set; }
        
        public long ReceiverId { get; set; }




        public User Receiver { get; set; }
        public Address Address { get; set; } 
        public ICollection<TrackingStatus> TrackingStatuses { get; set; }
        public ICollection<TrackingDescription> TrackingDescriptions { get; set; }
        public ICollection<ProductItem> ProductItems { get; set; }
    }

}
