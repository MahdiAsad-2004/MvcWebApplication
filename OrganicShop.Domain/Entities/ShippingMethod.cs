using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;
using System.ComponentModel;

namespace OrganicShop.Domain.Entities
{
    [DisplayName("حمل و نقل")]
    public class ShippingMethod : EntityId<byte>
    {
        public string Name { get; set; }
        
        public int Price { get; set; }
        

    }
}
