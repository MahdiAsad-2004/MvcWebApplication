using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Enums.Response;

namespace OrganicShop.Domain.Models
{
    public class ApplicationUser
    {
        public long Id { get; set; } = 1;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public Role? Role { get; set; } = null;
        public IEnumerable<byte> PermissionIds { get; set; } = Enumerable.Empty<byte>();





        ////private readonly PermissionsSeed permissionsSeed = new PermissionsSeed();
        //public bool HasPermission(List<Permission> permissions,Func<List<Permission>,byte> permissionIdFunc)
        //{
        //    var id = permissionIdFunc(permissions);
        //    return PermissionIds.Any(a => a.Equals(id));
        //}


    }
}
