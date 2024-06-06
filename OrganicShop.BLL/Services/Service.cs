using OrganicShop.BLL.Providers;
using OrganicShop.Domain.Response;
using OrganicShop.Domain;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.IProviders;
using OrganicShop.Domain.Response.Messages;
using OrganicShop.DAL.SeedDatas;

namespace OrganicShop.BLL.Services
{
    public abstract class Service<Entity> : IService<Entity> where Entity : IAggregateRoot
    {
        public Message<Entity> _Message { get; init; } = new Message<Entity>();
        public IApplicationUserProvider _AppUserProvider { get; init; }
        
        private PermissionsSeed PermissionsSeed = new PermissionsSeed();

        public Service(IApplicationUserProvider applicationUserProvider)
        {
            _AppUserProvider = applicationUserProvider;
        }


        public bool HasPermission(Func<PermissionsSeed, byte> permissionId)
        {
            var Title = permissionId.Invoke(PermissionsSeed);
            return _AppUserProvider.User.PermissionIds.Any(a => a.Equals(permissionId));
        }




    }
}
