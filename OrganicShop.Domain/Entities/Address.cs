using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;
using System.ComponentModel;

namespace OrganicShop.Domain.Entities
{
    [DisplayName("آدرس")]
    public class Address : EntityId<long>
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }
        public string ReceiverName { get; set; }
        public Province Province { get; set; }
        public long? UserId { get; set; }
        public int? SellerId { get; set; }



        public User? User { get; set; }
        public Seller? Seller { get; set; }


    }
}
