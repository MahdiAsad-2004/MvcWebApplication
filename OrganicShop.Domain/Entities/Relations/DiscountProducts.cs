using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Entities.Relations
{
    public class DiscountProducts : EntityId<int>
    {
        public int DiscountId { get; set; }
        public long ProductId { get; set; }
        
        
        public Discount Discount { get; set; }
        public Product Product { get; set; }
    }
}
