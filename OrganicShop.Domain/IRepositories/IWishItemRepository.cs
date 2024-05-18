using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Relations;

namespace OrganicShop.Domain.IRepositories
{
    public interface IWishItemRepository : IRepository,
        IReadRepository<WishItem, long>,
        IWriteRepository<WishItem, long>
    {

    }
}
