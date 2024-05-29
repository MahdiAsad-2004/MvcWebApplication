using OrganicShop.Domain.Entities.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrganicShop.Domain.Entities
{
    [DisplayName("سبد خرید")]
    public class Cart : EntityId<long>
    {
        public long UserId { get; set; }
        public int TotalPrice { get; set; }
        public bool IsMain { get; set; }




        [InverseProperty("Cart")]
        public User User { get; set; }


        [InverseProperty("NextCart")]
        public User Userr { get; set; }
        
        
        public ICollection<ProductItem> ProductItems { get; set; }


    }
}
