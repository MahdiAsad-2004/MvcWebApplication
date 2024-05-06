using OrganicShop.Domain.Entities;

namespace OrganicShop.Domain.IRepositories
{
    public interface INewsLetterRepository : IRepository,
        IReadRepository<NewsLetter, int>,
        IWriteRepository<NewsLetter, int>
    {

    }
}
