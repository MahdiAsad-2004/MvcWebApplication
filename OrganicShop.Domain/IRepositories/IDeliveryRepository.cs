using OrganicShop.Domain.Entities;


namespace OrganicShop.Domain.IRepositories
{
    public interface IDeliveryRepository : IRepository,
        IReadRepository<Delivery,byte>,
        IWriteRepository<Delivery,byte>
    {

    }
}
