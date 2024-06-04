using OrganicShop.DAL.Context;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;

namespace OrganicShop.DAL.Repositories
{
    public class NextCartRepository : CrudRepository<NextCart, long>, INextCartRepository
    {
        public NextCartRepository(OrganicShopDbContext organicShopDbContext) : base(organicShopDbContext)
        {
        }
    
    
    
       
    
    
    
    }
}
