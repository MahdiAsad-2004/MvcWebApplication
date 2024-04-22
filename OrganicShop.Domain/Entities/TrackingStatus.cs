using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Entities
{
    [DisplayName("وضعیت سفارش")]
    public class TrackingStatus : EntityId<long>
    {
        public DoneStatus DoneStatus { get; set; }
        public DateTime? DoneDate { get; set; }
        public OrderStep Step { get; set; }
        public long OrderId { get; set; }



        public Order Order { get; set; }
    }


}
