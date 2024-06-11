using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories.Base;

namespace OrganicShop.Domain.IRepositories
{
    public interface ICouponRepository : IRepository,
        IReadRepository<Coupon,int>,
        IWriteRepository<Coupon,int>
    {

    }
}
