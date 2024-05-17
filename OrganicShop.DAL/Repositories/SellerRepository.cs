using OrganicShop.DAL.Context;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;

namespace OrganicShop.DAL.Repositories
{
    public class SellerRepository : CrudRepository<Seller, int>, ISellerRepository
    {
        public SellerRepository(OrganicShopDbContext organicShopDbContext) : base(organicShopDbContext)
        {
        }
    }


}
