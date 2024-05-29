using OrganicShop.Domain.Entities;


namespace OrganicShop.Domain.IRepositories
{
    public interface IAddressRepository : IRepository,
        IReadRepository<Address,long>,
        IWriteRepository<Address,long>
    {

    }
}
