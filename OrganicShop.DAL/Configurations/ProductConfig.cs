using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.DAL.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
           


            builder.HasMany(a => a.Pictures).WithOne(a => a.Product).HasForeignKey(a => a.ProductId);
            builder.HasMany(a => a.ProductItems).WithOne(a => a.Product).HasForeignKey(a => a.ProductId);
            builder.HasOne(a => a.Category).WithMany(a => a.Products).HasForeignKey(a => a.CategoryId);
            builder.HasMany(a => a.DiscountProducts).WithOne(a => a.Product).HasForeignKey(a => a.ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(a => a.TagProducts).WithOne(a => a.Product).HasForeignKey(a => a.ProductId);
            builder.HasMany(a => a.Properties).WithOne(a => a.Product).HasForeignKey(a => a.ProductId);
            builder.HasMany(a => a.Comments).WithOne(a => a.Product).HasForeignKey(a => a.ProductId);
            builder.HasMany(a => a.UnitValues).WithOne(a => a.Product).HasForeignKey(a => a.ProductId);



            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);




        }
    }

    //public static class ProductConverter
    //{
    //    public static Product SetProducDiscunt( this Product product)
    //    {
    //        var discount = product.Discounts != null ? product.Discounts.LastOrDefault() : null;   
    //        if(discount != null)
    //        {
    //            product.Price = discount.Percent != null ? (product.Price - (product.Price * discount.Percent.Value)) : (product.Price - discount.FixedValue!.Value);
    //        }
    //        return product;
    //    }
 
    //}
}
