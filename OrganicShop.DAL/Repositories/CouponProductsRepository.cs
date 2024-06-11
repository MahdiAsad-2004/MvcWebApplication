using OrganicShop.DAL.Context;
using OrganicShop.DAL.Repositories.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Relations;
using OrganicShop.Domain.IRepositories;

namespace OrganicShop.DAL.Repositories
{
    public class CouponProductsRepository : CrudRepository<CouponProducts, int>, ICouponProductsRepository
    {
        public CouponProductsRepository(OrganicShopDbContext organicShopDbContext) : base(organicShopDbContext)
        {

        }
    }


}
