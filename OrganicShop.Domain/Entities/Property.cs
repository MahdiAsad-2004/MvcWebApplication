using OrganicShop.Domain.Entities.Base;
using System.ComponentModel;


namespace OrganicShop.Domain.Entities
{
    [DisplayName("ویژگی")]
    public class Property : EntityId<long>
    {
        public string Value { get; set; }
        public int PropertyTypeId { get; set; }
        public long? ProductId { get; set; }




        public Product Product { get; set; }
        public PropertyType? PropertyType { get; set; }

    }
}
