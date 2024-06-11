using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories.Base;


namespace OrganicShop.Domain.IRepositories
{
    public interface INextCartRepository : IRepository,
        IReadRepository<NextCart,long>,
        IWriteRepository<NextCart,long>
    {

    }
}
