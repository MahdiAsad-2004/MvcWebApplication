using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;
using System.ComponentModel;

namespace OrganicShop.Domain.Entities.Relations
{
    [DisplayName("علاقه مندی")]
    public class WishItem : EntityId<long>
    {
        public long UserId { get; set; }
        public long ProductId { get; set; }
        
        
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
