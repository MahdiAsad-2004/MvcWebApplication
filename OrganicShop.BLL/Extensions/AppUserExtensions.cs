
using OrganicShop.DAL.SeedDatas;
using OrganicShop.Domain.Models;

namespace OrganicShop.BLL.Extensions
{
    public static class AppUserExtensions
    {
        public static bool HasPermission(this ApplicationUser applicationUser,Func<PermissionsSeed, byte> func)
        {
            PermissionsSeed permissionsSeed = new PermissionsSeed();
            var id = func(permissionsSeed);
            return applicationUser.PermissionIds.Contains(id);
        }

    }
}
