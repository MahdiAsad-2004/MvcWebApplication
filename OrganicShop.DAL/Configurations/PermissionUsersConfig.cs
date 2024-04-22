using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Entities.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.DAL.Configurations
{
    public class PermissionUsersConfig : IEntityTypeConfiguration<PermissionUsers>
    {
        public void Configure(EntityTypeBuilder<PermissionUsers> builder)
        {
           


            builder.HasOne(a => a.Permission).WithMany(a => a.PermissionUsers).HasForeignKey(a => a.PermissionId);
            builder.HasOne(a => a.User).WithMany(a => a.PermissionUsers).HasForeignKey(a => a.UserId);



            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);
        }
    }
}
