using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Entities.Relations;
using System.ComponentModel;

namespace OrganicShop.Domain.Entities
{
    [DisplayName("مجوز")]
    public class Permission : EntityId<byte>
    {
        public string Title { get; set; }
        public string EnTitle { get; set; }
        public byte? ParentId { get; set; }



        public Permission Parent { get; set; }
        public ICollection<Permission> Subs { get; set; }
        public ICollection<PermissionUsers> PermissionUsers { get; set; }






        public List<Permission> GetAllChilds(List<Permission> permissions)
        {
            permissions.Add(this);
            if (this.Subs != null)
            {
                if (this.Subs.Any())
                {
                    foreach (var sub in this.Subs)
                    {
                        sub.GetAllChilds(permissions);
                    }
                }
            }
            return permissions;
        }


    }



}
