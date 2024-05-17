using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Entities.Base;
using System.ComponentModel;

namespace OrganicShop.Domain.Entities
{
    [DisplayName("نظر")]
    public class Comment: EntityId<long>
    {
        public int Rate { get; set; }
        public string Text { get; set; }
        public CommentStatus Status { get; set; }
        public string? Email { get; set; }
        public string? AuthorName { get; set; }
        public long? UserId { get; set; }
        public long? ProductId { get; set; }
        public int? ArticleId { get; set; }
        public int? SellerId { get; set; }



        public User? User { get; set; }
        public Product? Product { get; set; }
        public Article? Article { get; set; }
        public Seller? Seller { get; set; }



    }
}
