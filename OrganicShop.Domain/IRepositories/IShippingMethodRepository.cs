using OrganicShop.Domain.Entities;


namespace OrganicShop.Domain.IRepositories
{
    public interface IShippingMethodRepository : IRepository,
        IReadRepository<ShippingMethod,byte>,
        IWriteRepository<ShippingMethod,byte>
    {

    }
}
