using OrganicShop.Domain.Entities;

namespace OrganicShop.Domain.IRepositories
{
    public interface IProductVarientRepository : IRepository,
        IReadRepository<ProductVarient, long>,
        IWriteRepository<ProductVarient, long>
    {

    }
}
