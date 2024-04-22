using OrganicShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.IRepositories
{
    public interface IPermissionRepository : IRepository,
        IReadRepository<Permission,byte>,
        IWriteRepository<Permission,byte>
    {
        Task<bool> HasPermission(long userId , string PermissionEnTitle);

        Task<bool> HasPermission(long userId , int permissionId);
    }
}
