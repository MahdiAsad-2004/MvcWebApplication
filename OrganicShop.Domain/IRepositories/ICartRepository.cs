using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories.Base;


namespace OrganicShop.Domain.IRepositories
{
    public interface ICartRepository : IRepository,
        IReadRepository<Cart,long>,
        IWriteRepository<Cart,long>
    {

    }
}
