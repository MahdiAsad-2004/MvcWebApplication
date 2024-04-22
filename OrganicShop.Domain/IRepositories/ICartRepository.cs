using OrganicShop.Domain.Entities;


namespace OrganicShop.Domain.IRepositories
{
    public interface ICartRepository : IRepository,
        IReadRepository<Cart,long>,
        IWriteRepository<Cart,long>
    {

    }
}
