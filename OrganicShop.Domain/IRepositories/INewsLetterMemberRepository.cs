using OrganicShop.Domain.Entities;

namespace OrganicShop.Domain.IRepositories
{
    public interface INewsLetterMemberRepository : IRepository,
        IReadRepository<NewsLetterMember, int>,
        IWriteRepository<NewsLetterMember, int>
    {

    }
}
