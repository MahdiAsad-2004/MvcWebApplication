using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories.Base;

namespace OrganicShop.Domain.IRepositories
{
    public interface ISellerRepository : IRepository,
        IReadRepository<Seller, int>,
        IWriteRepository<Seller, int>
    {

    }
}
