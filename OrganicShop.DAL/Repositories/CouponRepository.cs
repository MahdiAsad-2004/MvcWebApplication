using Microsoft.EntityFrameworkCore;
using OrganicShop.DAL.Context;
using OrganicShop.DAL.Repositories.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Relations;
using OrganicShop.Domain.IRepositories;

namespace OrganicShop.DAL.Repositories
{
    public class CouponRepository : CrudRepository<Coupon, int>, ICouponRepository
    {
        public CouponRepository(OrganicShopDbContext organicShopDbContext) : base(organicShopDbContext)
        {
        }
    }


}
