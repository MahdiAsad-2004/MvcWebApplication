using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;
namespace OrganicShop.DAL.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {


            builder.HasMany(a => a.Addresses).WithOne(a => a.User).HasForeignKey(a => a.UserId);
            builder.HasMany(a => a.Comments).WithOne(a => a.User).HasForeignKey(a => a.UserId);
            builder.HasMany(a => a.BankCards).WithOne(a => a.User).HasForeignKey(a => a.UserId);
            builder.HasMany(a => a.Operations).WithOne(a => a.User).HasForeignKey(a => a.UserId);
            builder.HasMany(a => a.Orders).WithOne(a => a.Receiver).HasForeignKey(a => a.UserId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(a => a.PermissionUsers).WithOne(a => a.User).HasForeignKey(a => a.UserId);
            builder.HasMany(a => a.Articles).WithOne(a => a.User).HasForeignKey(a => a.UserId);
            builder.HasOne(a => a.Picture).WithOne(a => a.User).HasForeignKey<Picture>(a => a.UserId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(a => a.Seller).WithOne(a => a.User).HasForeignKey<Seller>(a => a.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(a => a.WishItems).WithOne(a => a.User).HasForeignKey(a => a.UserId);
            builder.HasMany(a => a.UserMessages).WithOne(a => a.User).HasForeignKey(a => a.UserId);
            builder.HasOne(a => a.Cart).WithOne(a => a.User).HasForeignKey<Cart>(a => a.UserId);
            builder.HasOne(a => a.NextCart).WithOne(a => a.User).HasForeignKey<NextCart>(a => a.UserId);




            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);


            


            builder.HasData(
                new User
                {
                    Id = 1,
                    Name = "Mahdi Asadi",
                    Password = "123456",
                    PhoneNumber = "09369753041",
                    Email = "mas1379as@gmail.com",
                    Role = Role.Admin,
                },
                new User
                {
                    Id = 2,
                    Name = "AmirAli",
                    Password = "1234",
                    PhoneNumber = "09331234566",
                    Email = "TestEmail@gmail.com",
                    Role = Role.Customer,
                });

            builder.OwnsOne(a => a.BaseEntity).HasData(new
            {
                UserId = (long)1,
                CreateDate = DateTime.Now,
                LastModified = DateTime.Now,
                IsActive = true,
                IsDelete = false,
            });
            builder.OwnsOne(a => a.BaseEntity).HasData(new
            {
                UserId = (long)2,
                CreateDate = DateTime.Now,
                LastModified = DateTime.Now,
                IsActive = true,
                IsDelete = false,

            });


        }
    }
}
