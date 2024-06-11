using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories.Base;

namespace OrganicShop.Domain.IRepositories
{
    public interface IUserMessageRepository : IRepository,
        IReadRepository<UserMessage, int>,
        IWriteRepository<UserMessage, int>
    {

    }
}
