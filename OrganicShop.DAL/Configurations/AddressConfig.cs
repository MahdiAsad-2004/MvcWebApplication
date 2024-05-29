using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.DAL.Configurations
{
    public class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {


            builder.HasOne(a => a.User).WithMany(a => a.Addresses).HasForeignKey(a => a.UserId);
            builder.HasOne(a => a.Seller).WithOne(a => a.Address).HasForeignKey<Address>(a => a.SellerId);
            //builder.HasMany(a => a.Orders).WithOne(a => a.Address).HasForeignKey(a => a.AddressId);

            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);




            //builder.HasData(new Address
            //{
            //    Id = 1,
            //    Title = "address 1",
            //    Phone = "02132227610",
            //    PostCode = "12345",
            //    Text = "text",
            //    UserId = 1,
            //});

            //builder.OwnsOne(a => a.BaseEntity).HasData(new
            //{
            //    AddressId = (long)1,
            //    CreateDate = DateTime.Now,
            //    LastModified = DateTime.Now,
            //    IsActive = true,
            //});
            //builder.OwnsOne(a => a.BaseEntity).HasData(new
            //{
            //    AddressId = (long)1,
            //    IsDelete = false,
            //    //DeleteDate = null,
            //});

            //builder.HasData(new Address
            //{
            //    Id = 2,
            //    Title = "address 2",
            //    Phone = "02132227610",
            //    PostCode = "12345",
            //    Text = "text",
            //    UserId = 1,
            //});

            //builder.OwnsOne(a => a.BaseEntity).HasData(new
            //{
            //    AddressId = (long)2,
            //    CreateDate = DateTime.Now,
            //    LastModified = DateTime.Now,
            //    IsActive = true,
            //});
            //builder.OwnsOne(a => a.BaseEntity).HasData(new
            //{
            //    AddressId = (long)2,
            //    IsDelete = false,
            //    //DeleteDate = null,
            //});



            //builder.HasData(new Address
            //{
            //    Id = 3,
            //    Title = "address 3",
            //    Phone = "02132227610",
            //    PostCode = "12345",
            //    Text = "text",
            //    UserId = 1,
            //});

            //builder.OwnsOne(a => a.BaseEntity).HasData(new
            //{
            //    AddressId = (long)3,
            //    CreateDate = DateTime.Now,
            //    LastModified = DateTime.Now,
            //    IsActive = true,
            //});
            //builder.OwnsOne(a => a.BaseEntity).HasData(new
            //{
            //    AddressId = (long)3,
            //    IsDelete = true,
            //    DeleteDate = DateTime.Now,
            //});



        }
    }
}
