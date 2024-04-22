using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Entities.Relations
{
    public class DiscountCategories : EntityId<int>
    {
        public int DiscountId { get; set; }
        public int CategoryId { get; set; }
        
        
        public Discount Discount { get; set; }
        public Category Category { get; set; }
    }
}
