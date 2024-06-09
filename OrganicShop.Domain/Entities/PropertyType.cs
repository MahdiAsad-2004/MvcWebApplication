using OrganicShop.Domain.Entities.Base;
using System.ComponentModel;


namespace OrganicShop.Domain.Entities
{
    [DisplayName("ویژگی")]
    public class PropertyType : EntityId<int>
    {
        public string Title { get; set; }
        public int Priority { get; set; }



        public ICollection<Property> Properties { get; set; }

    }
}
