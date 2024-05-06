using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Entities.Relations;
using System.ComponentModel;

namespace OrganicShop.Domain.Entities
{
    [DisplayName("خبرنامه")]
    public class NewsLetter : EntityId<int>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime SendDate { get; set; }
    }
}
