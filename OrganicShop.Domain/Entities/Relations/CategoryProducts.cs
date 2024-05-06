using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Entities.Relations
{
    public class CategoryProducts : EntityId<int>
    {
        public int CategoryIdId { get; set; }
        public long ProductId { get; set; }
        
        
        public Category Category { get; set; }
        public Product Product { get; set; }
    }
}
