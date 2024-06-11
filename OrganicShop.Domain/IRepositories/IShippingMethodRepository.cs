using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories.Base;


namespace OrganicShop.Domain.IRepositories
{
    public interface IShippingMethodRepository : IRepository,
        IReadRepository<ShippingMethod,byte>,
        IWriteRepository<ShippingMethod,byte>
    {

    }
}
