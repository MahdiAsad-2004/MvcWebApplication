using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Entities.Relations;
using System.ComponentModel;

namespace OrganicShop.Domain.Entities
{
    [DisplayName("مقاله")]
    public class Article : EntityId<int>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ShortDescription { get; set; }
        public long UserId { get; set; }
        public int CategoryId { get; set; }


        public User User { get; set; }
        public Category Category { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Picture> Pictures { get; set; }
        public ICollection<TagArticles> TagArticles { get; set; }

    }
}
