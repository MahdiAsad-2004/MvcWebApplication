using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Entities.SeedDatas;
using OrganicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.DAL.Configurations
{
    public class PermissionConfig : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {


            builder.HasMany(a => a.Subs).WithOne(a => a.Parent).HasForeignKey(a => a.ParentId);
            builder.HasMany(a => a.PermissionUsers).WithOne(a => a.Permission).HasForeignKey(a => a.PermissionId);
            builder.Property(a => a.ParentId).IsRequired(false);
            builder.Property(a => a.ParentId).HasDefaultValue(null);


            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);

            builder.HasData(PermissionsSeed.Permissions);

            var permissionsBaseEntity = new List<object>();
            
            foreach (var item in PermissionsSeed.Permissions)
            {
               permissionsBaseEntity.Add(new
               {
                   PermissionId = (byte)item.Id,
                   CreateDate = DateTime.Now,
                   LastModified = DateTime.Now,
                   IsActive = true,
                   IsDelete = false,
               });
            }

            builder.OwnsOne(a => a.BaseEntity).HasData(permissionsBaseEntity);









            //foreach (var item in PermissionsSeed.Permissions)
            //{
            //    builder.OwnsOne(a => a.BaseEntity).HasData(new
            //    {
            //        PermissionId = (byte)item.Id,
            //        CreateDate = DateTime.Now,
            //        LastModified = DateTime.Now,
            //        IsActive = true,
            //        IsDelete = false,
            //    });
            //}


            ////-----------------------------------------------------------------

            ////builder.HasData(new Permission
            ////{
            ////    Id = 1,
            ////    Title = "مدیر سایت",
            ////    EnTitle = "Main Admin",
            ////});
            //builder.OwnsOne(a => a.BaseEntity).HasData(new
            //{
            //    PermissionId = (byte)1,
            //    CreateDate = DateTime.Now,
            //    LastModified = DateTime.Now,
            //    IsActive = true,
            //    IsDelete = false,
            //});

            ////------------------------------------------------------------------

            ////builder.HasData(new Permission
            ////{
            ////    Id = 2,
            ////    Title = "مدیریت کاربران",
            ////    EnTitle = "Users Admin",
            ////    ParentId = 1,
            ////});
            //builder.OwnsOne(a => a.BaseEntity).HasData(new
            //{
            //    PermissionId = (byte)2,
            //    CreateDate = DateTime.Now,
            //    LastModified = DateTime.Now,
            //    IsActive = true,
            //    IsDelete = false,
            //});

            ////-----------------------------------------------------------------

            ////builder.HasData(new Permission
            ////{
            ////    Id = 3,
            ////    Title = "مدیریت محصولات",
            ////    EnTitle = "Products Admin",
            ////    ParentId = 1,
            ////});
            //builder.OwnsOne(a => a.BaseEntity).HasData(new
            //{
            //    PermissionId = (byte)3,
            //    CreateDate = DateTime.Now,
            //    LastModified = DateTime.Now,
            //    IsActive = true,
            //    IsDelete = false,
            //});

            ////-----------------------------------------------------------------

            ////builder.HasData(new Permission
            ////{
            ////    Id = 4,
            ////    Title = "مدیریت مجوز ها",
            ////    EnTitle = "Permissions Admin",
            ////    ParentId = 1,

            ////});
            //builder.OwnsOne(a => a.BaseEntity).HasData(new
            //{
            //    PermissionId = (byte)4,
            //    CreateDate = DateTime.Now,
            //    LastModified = DateTime.Now,
            //    IsActive = true,
            //    IsDelete = false,
            //});

            ////-----------------------------------------------------------------

            ////builder.HasData(new Permission
            ////{
            ////    Id = 5,
            ////    Title = "مدیریت نظرات",
            ////    EnTitle = "Comments Admin",
            ////    ParentId = 1,

            ////});
            //builder.OwnsOne(a => a.BaseEntity).HasData(new
            //{
            //    PermissionId = (byte)5,
            //    CreateDate = DateTime.Now,
            //    LastModified = DateTime.Now,
            //    IsActive = true,
            //    IsDelete = false,
            //});

            ////-----------------------------------------------------------------

            ////builder.HasData(new Permission
            ////{
            ////    Id = 6,
            ////    Title = "مدیریت تخفیف ها",
            ////    EnTitle = "Discounts Admin",
            ////    ParentId = 1,

            ////});
            //builder.OwnsOne(a => a.BaseEntity).HasData(new
            //{
            //    PermissionId = (byte)6,
            //    CreateDate = DateTime.Now,
            //    LastModified = DateTime.Now,
            //    IsActive = true,
            //    IsDelete = false,
            //});

            ////-----------------------------------------------------------------

            ////builder.HasData(new Permission
            ////{
            ////    Id = 7,
            ////    Title = "صدور مجوز",
            ////    EnTitle = "Giving Permission",
            ////    ParentId = 4,

            ////});
            //builder.OwnsOne(a => a.BaseEntity).HasData(new
            //{
            //    PermissionId = (byte)7,
            //    CreateDate = DateTime.Now,
            //    LastModified = DateTime.Now,
            //    IsActive = true,
            //    IsDelete = false,
            //});


            ////-----------------------------------------------------------------

            //builder.OwnsOne(a => a.BaseEntity).HasData(new
            //{
            //    PermissionId = (byte)8,
            //    CreateDate = DateTime.Now,
            //    LastModified = DateTime.Now,
            //    IsActive = true,
            //    IsDelete = false,
            //});
        }
    }
}
