using Microsoft.EntityFrameworkCore;
using OrganicShop.DAL.Context;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.DAL.Repositories
{
    public class PermissionRepository : CrudRepository<Permission, byte>, IPermissionRepository
    {
        public PermissionRepository(OrganicShopDbContext organicShopDbContext) : base(organicShopDbContext)
        {
        }

        public async Task<bool> HasPermission(long userId ,int permissionId)
        {
            var allPermissions = new List<Permission>();
            var permissions = _context.PermissionUsers
                .Include(a => a.Permission)
                .ThenInclude(a => a.Subs)
                .Where(a => a.UserId == userId)
                .Select(a => a.Permission)
                .ToArray();  

            if(permissions != null)
            {
                foreach (var permission in permissions)
                {
                    permission.GetAllChilds(allPermissions);
                }
            }

            return allPermissions.Any(a => a.Id == permissionId);
        }

        public async Task<bool> HasPermission(long userId, string permissionEnTitle)
        {
            var allPermissions = new List<Permission>();
            var permissions = _context.PermissionUsers
                .Include(a => a.Permission)
                .ThenInclude(a => a.Subs)
                .Where(a => a.UserId == userId)
                .Select(a => a.Permission)
                .ToArray();

            if (permissions != null)
            {
                foreach (var permission in permissions)
                {
                    permission.GetAllChilds(allPermissions);
                }
            }

            return allPermissions.Any(a => a.EnTitle == permissionEnTitle);
        }
    }


}
