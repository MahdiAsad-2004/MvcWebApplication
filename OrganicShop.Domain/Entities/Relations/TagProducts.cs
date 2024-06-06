using OrganicShop.Domain.Entities.Base;
using System.ComponentModel;

namespace OrganicShop.Domain.Entities.Relations
{
    [DisplayName("برچسب محصول")]
    public class TagProducts : EntityId<int>
    {
        public int TagId { get; set; }
        public long ProductId { get; set; }
        
        
        public Tag Tag { get; set; }
        public Product Product { get; set; }
    }
}
