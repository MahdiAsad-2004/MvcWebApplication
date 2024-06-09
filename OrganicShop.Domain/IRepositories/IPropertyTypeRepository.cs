using OrganicShop.Domain.Entities;

namespace OrganicShop.Domain.IRepositories
{
    public interface IPropertyTypeRepository : IRepository,
        IReadRepository<PropertyType, int>,
        IWriteRepository<PropertyType, int>
    {

    }
}
