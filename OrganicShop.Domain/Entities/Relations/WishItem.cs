using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Entities.Relations
{
    public class WishItem : EntityId<long>
    {
        public int UserId { get; set; }
        public long ProductId { get; set; }
        
        
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
