using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Entities.Relations;
using System.ComponentModel;

namespace OrganicShop.Domain.Entities
{
    [DisplayName("فروشنده")]
    public class Seller : EntityId<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public long UserId { get; set; }



        public ICollection<Product> Products { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public Address Address { get; set; }
        public Picture Picture { get; set; }
        public User User { get; set; }
    
    }
}
