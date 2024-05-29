using Microsoft.Identity.Client;
using OrganicShop.DAL.Context;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;


namespace OrganicShop.DAL.Repositories
{
    public class ProductItemRepository : CrudRepository<ProductItem, long>, IProductItemRepository
    {
        public ProductItemRepository(OrganicShopDbContext organicShopDbContext) : base(organicShopDbContext)
        {
            
        }
    }


}
