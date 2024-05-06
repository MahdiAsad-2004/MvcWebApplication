using OrganicShop.Domain.Entities;

namespace OrganicShop.Domain.IRepositories
{
    public interface ITagRepository : IRepository,
        IReadRepository<Tag, int>,
        IWriteRepository<Tag, int>
    {

    }
}
