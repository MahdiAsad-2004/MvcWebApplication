using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Relations;
using OrganicShop.Domain.IRepositories.Base;

namespace OrganicShop.Domain.IRepositories
{
    public interface ICouponProductsRepository : IRepository,
        IReadRepository<CouponProducts,int>,
        IWriteRepository<CouponProducts,int>
    {

    }
}
