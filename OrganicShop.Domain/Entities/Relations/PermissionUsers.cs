using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Entities.Relations
{
    public class PermissionUsers : EntityId<int>
    {
        public byte PermissionId { get; set; }
        public long UserId { get; set; }
        
        
        public Permission Permission { get; set; }
        public User User { get; set; }
    }
}
