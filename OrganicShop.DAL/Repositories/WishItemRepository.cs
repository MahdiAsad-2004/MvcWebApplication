using OrganicShop.DAL.Context;
using OrganicShop.DAL.Repositories.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Relations;
using OrganicShop.Domain.IRepositories;

namespace OrganicShop.DAL.Repositories
{
    public class WishItemRepository : CrudRepository<WishItem, long>, IWishItemRepository
    {
        public WishItemRepository(OrganicShopDbContext organicShopDbContext) : base(organicShopDbContext)
        {
        }
    }


}
