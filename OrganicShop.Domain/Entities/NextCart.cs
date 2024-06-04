using OrganicShop.Domain.Entities.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrganicShop.Domain.Entities
{
    [DisplayName("سبد خرید بعدی")]
    public class NextCart : EntityId<long>
    {
        public long UserId { get; set; }
     


        public User User { get; set; }        
        public ICollection<ProductItem> ProductItems { get; set; }

    }
}
