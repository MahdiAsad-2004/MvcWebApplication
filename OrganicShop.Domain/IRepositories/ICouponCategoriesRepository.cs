using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Relations;
using OrganicShop.Domain.IRepositories.Base;

namespace OrganicShop.Domain.IRepositories
{
    public interface ICouponCategoriesRepository : IRepository,
        IReadRepository<CouponCategories, int>,
        IWriteRepository<CouponCategories, int>
    {
      
    }
}
