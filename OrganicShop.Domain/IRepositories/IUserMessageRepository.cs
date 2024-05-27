using OrganicShop.Domain.Entities;

namespace OrganicShop.Domain.IRepositories
{
    public interface IUserMessageRepository : IRepository,
        IReadRepository<UserMessage, int>,
        IWriteRepository<UserMessage, int>
    {

    }
}
