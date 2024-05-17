using OrganicShop.Domain.Entities;

namespace OrganicShop.Domain.IRepositories
{
    public interface ISellerRepository : IRepository,
        IReadRepository<Seller, int>,
        IWriteRepository<Seller, int>
    {

    }
}
