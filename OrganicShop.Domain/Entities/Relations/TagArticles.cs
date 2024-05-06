using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Entities.Relations
{
    public class TagArticles : EntityId<int>
    {
        public int TagId { get; set; }
        public int ArticleId { get; set; }
        
        
        public Tag Tag { get; set; }
        public Article Article { get; set; }
    }
}
