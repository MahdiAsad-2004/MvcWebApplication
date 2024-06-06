using OrganicShop.Domain.Entities.Base;
using System.ComponentModel;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Entities.Relations
{
    [DisplayName("مجوز کاربر")]
    public class PermissionUsers : EntityId<int>
    {
        public byte PermissionId { get; set; }
        public long UserId { get; set; }
        
        
        public Permission Permission { get; set; }
        public User User { get; set; }
    }
}
