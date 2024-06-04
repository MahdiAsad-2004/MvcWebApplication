using OrganicShop.Domain.Entities;


namespace OrganicShop.Domain.IRepositories
{
    public interface INextCartRepository : IRepository,
        IReadRepository<NextCart,long>,
        IWriteRepository<NextCart,long>
    {

    }
}
