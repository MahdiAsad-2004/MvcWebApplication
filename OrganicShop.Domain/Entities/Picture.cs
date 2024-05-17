using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;
using System.ComponentModel;

namespace OrganicShop.Domain.Entities
{
    [DisplayName("تصویر")]
    public class Picture : EntityId<long>
    { 
        public string Name { get; set; }
        public float SizeMB { get; set; }
        public bool IsMain { get; set; }
        public PictureType Type { get; set; }
        public long? ProductId { get; set; }
        public long? UserId { get; set; }
        public int? CategoryId { get; set; }
        public int? ArticleId { get; set; }
        public int? SellerId { get; set; }


        public Product? Product { get; set; }
        public User? User { get; set; }
        public Category? Category { get; set; }
        public Article? Article { get; set; }
        public Seller? Seller { get; set; }



    }
}
