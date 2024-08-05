using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;

namespace OrganicShop.DAL.Configurations
{
    public class ShippingMethodConfig : IEntityTypeConfiguration<ShippingMethod>
    {
        public void Configure(EntityTypeBuilder<ShippingMethod> builder)
        {

            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);






            builder.HasData(new ShippingMethod
            {
                Id = 1,
                Name = "پست پیشتاز",
                Price = 30_000,
            });

            builder.HasData(new ShippingMethod
            {
                Id = 2,
                Name = "پست سفارشی",
                Price = 50_000,
            });
            builder.HasData(new ShippingMethod
            {
                Id = 3,
                Name = "تیپاکس",
                Price = 100_000,
            });
            builder.HasData(new ShippingMethod
            {
                Id = 4,
                Name = "پیک موتوری",
                Price = 120_000,
            });
            builder.OwnsOne(a => a.BaseEntity).HasData(new
            {
                ShippingMethodId = (byte)1,
                CreateDate = DateTime.Now,
                LastModified = DateTime.Now,
                IsActive = true,
                IsDelete = false,
            });
            builder.OwnsOne(a => a.BaseEntity).HasData(new
            {
                ShippingMethodId = (byte)2,
                CreateDate = DateTime.Now,
                LastModified = DateTime.Now,
                IsActive = true,
                IsDelete = false,
            });
            builder.OwnsOne(a => a.BaseEntity).HasData(new
            {
                ShippingMethodId = (byte)3,
                CreateDate = DateTime.Now,
                LastModified = DateTime.Now,
                IsActive = true,
                IsDelete = false,
            });
            builder.OwnsOne(a => a.BaseEntity).HasData(new
            {
                ShippingMethodId = (byte)4,
                CreateDate = DateTime.Now,
                LastModified = DateTime.Now,
                IsActive = true,
                IsDelete = false,
            });




        }
    }
}
