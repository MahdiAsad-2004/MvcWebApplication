using OrganicShop.Domain.Entities.Base;
using System.ComponentModel;
using OrganicShop.Domain.Entities.Relations;

namespace OrganicShop.Domain.Entities
{
    [DisplayName("پیام کاربر")]
    public class UserMessage : EntityId<int>
    {
        public string Text { get; set; }
        public string IPAddress { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public long? UserId { get; set; }


        public User? User { get; set; }
    }
}
