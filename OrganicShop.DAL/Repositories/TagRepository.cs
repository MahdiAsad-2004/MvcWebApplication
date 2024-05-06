using OrganicShop.DAL.Context;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;

namespace OrganicShop.DAL.Repositories
{
    public class TagRepository : CrudRepository<Tag, int>, ITagRepository
    {
        public TagRepository(OrganicShopDbContext organicShopDbContext) : base(organicShopDbContext)
        {
        }
    }


}
