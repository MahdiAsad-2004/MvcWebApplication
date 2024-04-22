using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.SeedDatas;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Enums.Response;

namespace OrganicShop.Domain.Models
{
    public class ApplicationUser
    {
        public long Id { get; set; } = 0;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Role? Role { get; set; } = null;
        public IEnumerable<byte> PermissionIds { get; set; } = Enumerable.Empty<byte>();





        private readonly PermissionsSeed permissionsSeed = new PermissionsSeed();
        public bool HasPermission(Func<PermissionsSeed,byte> permissionId)
        {
            var id = permissionId.Invoke(permissionsSeed);
            return PermissionIds.Any(a => a.Equals(id));
        }


    }
}
