using OrganicShop.DAL.Context;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.DAL.Repositories
{
    public class ProductRepository : CrudRepository<Product, long>, IProductRepository
    {
        public ProductRepository(OrganicShopDbContext organicShopDbContext) : base(organicShopDbContext)
        {
            
        }

        
    }


}
