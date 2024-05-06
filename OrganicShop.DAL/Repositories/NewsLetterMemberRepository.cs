using OrganicShop.DAL.Context;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;

namespace OrganicShop.DAL.Repositories
{
    public class NewsLetterMemberRepository : CrudRepository<NewsLetterMember, int>, INewsLetterMemberRepository
    {
        public NewsLetterMemberRepository(OrganicShopDbContext organicShopDbContext) : base(organicShopDbContext)
        {
        }
    }


}
