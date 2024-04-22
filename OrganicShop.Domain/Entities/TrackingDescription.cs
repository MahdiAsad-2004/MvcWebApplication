using OrganicShop.Domain.Entities.Base;
using System.ComponentModel;

namespace OrganicShop.Domain.Entities
{
    [DisplayName("شرح سفارش")]
    public class TrackingDescription : EntityId<long>
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public long OrderId { get; set;  }


        public Order Order { get; set; }

    }


}
