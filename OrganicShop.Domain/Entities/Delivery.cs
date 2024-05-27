using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;
using System.ComponentModel;

namespace OrganicShop.Domain.Entities
{
    [DisplayName("حمل و نقل")]
    public class Delivery : EntityId<byte>
    {
        public string Type { get; set; }
        
        public int Price { get; set; }
        

    }
}
