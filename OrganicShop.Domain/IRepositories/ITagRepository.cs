using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories.Base;

namespace OrganicShop.Domain.IRepositories
{
    public interface ITagRepository : IRepository,
        IReadRepository<Tag, int>,
        IWriteRepository<Tag, int>
    {

    }
}
