using System.ComponentModel;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Entities.Relations
{
    [DisplayName("دسته بندی محصول")]
    public class CategoryProducts : EntityId<int>
    {
        public int CategoryIdId { get; set; }
        public long ProductId { get; set; }
        
        
        public Category Category { get; set; }
        public Product Product { get; set; }
    }
}
