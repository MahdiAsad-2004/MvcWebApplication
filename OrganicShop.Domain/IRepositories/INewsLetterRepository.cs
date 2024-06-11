using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories.Base;

namespace OrganicShop.Domain.IRepositories
{
    public interface INewsLetterRepository : IRepository,
        IReadRepository<NewsLetter, int>,
        IWriteRepository<NewsLetter, int>
    {

    }
}
