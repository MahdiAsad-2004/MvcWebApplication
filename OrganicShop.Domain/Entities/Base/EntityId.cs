namespace OrganicShop.Domain.Entities.Base
{
    public abstract class EntityId<Key> : IAggregateRoot where Key : struct 
    {
        public  Key Id { get; set; }
        public BaseEntity BaseEntity { get; set; }

    }

}
