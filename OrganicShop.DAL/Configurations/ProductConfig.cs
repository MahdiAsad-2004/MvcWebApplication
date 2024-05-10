﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Dtos.ProductDtos;

namespace OrganicShop.DAL.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
           


            builder.HasMany(a => a.Pictures).WithOne(a => a.Product).HasForeignKey(a => a.ProductId);
            builder.HasMany(a => a.ProductItems).WithOne(a => a.Product).HasForeignKey(a => a.ProductId);
            builder.HasMany(a => a.Categories).WithMany(a => a.Products);
            builder.HasMany(a => a.DiscountProducts).WithOne(a => a.Product).HasForeignKey(a => a.ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(a => a.TagProducts).WithOne(a => a.Product).HasForeignKey(a => a.ProductId);
            builder.HasMany(a => a.Properties).WithOne(a => a.Product).HasForeignKey(a => a.ProductId);
            builder.HasMany(a => a.Comments).WithOne(a => a.Product).HasForeignKey(a => a.ProductId);



            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);

        }
    }


}
