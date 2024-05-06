using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Entities.Relations;
using System.ComponentModel;

namespace OrganicShop.Domain.Entities
{
    [DisplayName("عضو خبرنامه")]
    public class NewsLetterMember : EntityId<int>
    {
        public string Email { get; set; }
        public long? UserId { get; set; }


        public User? User { get; set; }

    }
}
