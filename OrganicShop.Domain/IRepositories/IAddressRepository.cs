using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories.Base;


namespace OrganicShop.Domain.IRepositories
{
    public interface IAddressRepository : IRepository,
        IReadRepository<Address,long>,
        IWriteRepository<Address,long>
    {

    }
}
