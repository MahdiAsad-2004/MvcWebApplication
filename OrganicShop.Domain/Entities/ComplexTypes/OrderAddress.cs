using OrganicShop.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrganicShop.Domain.Entities.ComplexTypes
{
    [ComplexType]
    public class OrderAddress
    {
        public long AddressId { get; set; }
        public string Text { get; set; }
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }
        public string ReceiverName { get; set; }
        public Province Province { get; set; }


    }


}
