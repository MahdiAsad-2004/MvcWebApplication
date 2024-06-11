using OrganicShop.DAL.Context;
using OrganicShop.DAL.Repositories.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;

namespace OrganicShop.DAL.Repositories
{
    public class ProductVarientRepository : CrudRepository<ProductVarient, long>, IProductVarientRepository
    {
        public ProductVarientRepository(OrganicShopDbContext organicShopDbContext) : base(organicShopDbContext)
        {
        }
    }


}
