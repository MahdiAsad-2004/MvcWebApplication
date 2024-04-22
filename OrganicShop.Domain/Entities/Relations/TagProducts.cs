using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Entities.Relations
{
    public class TagProducts : EntityId<int>
    {
        public int TagId { get; set; }
        public long ProductId { get; set; }
        
        
        public Tag Tag { get; set; }
        public Product Product { get; set; }
    }
}
