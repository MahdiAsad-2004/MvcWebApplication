using OrganicShop.DAL.Context;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;

namespace OrganicShop.DAL.Repositories
{
    public class PropertyTypeRepository : CrudRepository<PropertyType, int>, IPropertyTypeRepository
    {
        public PropertyTypeRepository(OrganicShopDbContext organicShopDbContext) : base(organicShopDbContext)
        {
        }
    }


}
