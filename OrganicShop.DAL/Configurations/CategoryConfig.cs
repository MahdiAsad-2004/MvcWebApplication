using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;

namespace OrganicShop.DAL.Configurations
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
           
            builder.HasMany(a =>a.Subs).WithOne(a => a.Parent).HasForeignKey(a => a.ParentId);
            builder.HasMany(a =>a.Products).WithMany(a => a.Categories);
            builder.HasMany(a =>a.Articles).WithOne(a => a.Category).HasForeignKey(a => a.CategoryId);
            builder.HasOne(a => a.Picture).WithOne(a => a.Category).HasForeignKey<Picture>(a => a.CategoryId).OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(a =>a.CouponCategories).WithOne(a => a.Category).HasForeignKey(a => a.CategoryId);


            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);
        }
    }
}
