using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories.Base;

namespace OrganicShop.Domain.IRepositories
{
    public interface IProductVarientRepository : IRepository,
        IReadRepository<ProductVarient, long>,
        IWriteRepository<ProductVarient, long>
    {

    }
}
