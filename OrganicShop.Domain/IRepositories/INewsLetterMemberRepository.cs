using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories.Base;

namespace OrganicShop.Domain.IRepositories
{
    public interface INewsLetterMemberRepository : IRepository,
        IReadRepository<NewsLetterMember, int>,
        IWriteRepository<NewsLetterMember, int>
    {

    }
}
