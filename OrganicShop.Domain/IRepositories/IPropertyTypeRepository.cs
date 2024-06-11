using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories.Base;

namespace OrganicShop.Domain.IRepositories
{
    public interface IPropertyTypeRepository : IRepository,
        IReadRepository<PropertyType, int>,
        IWriteRepository<PropertyType, int>
    {

    }
}
