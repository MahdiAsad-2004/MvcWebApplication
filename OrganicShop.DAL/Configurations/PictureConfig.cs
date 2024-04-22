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
    public class PictureConfig : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.HasOne<Product>(a => a.Product).WithMany(a => a.Pictures).HasForeignKey(a => a.ProductId);
            builder.HasOne(a => a.Category).WithOne(a => a.Picture).HasForeignKey<Picture>(a => a.CategoryPictureId);
            builder.HasOne(a => a.User).WithOne(a => a.Picture).HasForeignKey<Picture>(a => a.UserPictureId);



            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);



            
            builder.HasData(new Picture()
            {
                Id = 1,
                IsMain = true,
                Name = "jocker.png",
                SizeMB = 0.5f,
                UserPictureId = 1,
            });
            builder.OwnsOne(a => a.BaseEntity).HasData(new
            {
                PictureId = (long)1,
                CreateDate = DateTime.Now,
                LastModified = DateTime.Now,
                IsActive = true,
                IsDelete = false,
            });



        }
    }
}
