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
            builder.HasOne(a => a.Product).WithMany(a => a.Pictures).HasForeignKey(a => a.ProductId);
            builder.HasOne(a => a.Article).WithMany(a => a.Pictures).HasForeignKey(a => a.ArticleId);
            builder.HasOne(a => a.Category).WithOne(a => a.Picture).HasForeignKey<Picture>(a => a.CategoryId).OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(a => a.User).WithOne(a => a.Picture).HasForeignKey<Picture>(a => a.UserId).OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(a => a.Seller).WithOne(a => a.Picture).HasForeignKey<Picture>(a => a.SellerId).OnDelete(DeleteBehavior.SetNull);



            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);



            
            builder.HasData(new Picture()
            {
                Id = 1,
                IsMain = true,
                Name = "joker.png",
                SizeMB = 0.5f,
                UserId = 1,
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
