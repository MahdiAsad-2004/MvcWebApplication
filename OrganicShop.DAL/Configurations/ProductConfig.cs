using Microsoft.EntityFrameworkCore;
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
            //builder.HasMany(a => a.CategoryProducts).WithOne(a => a.Product).HasForeignKey(a => a.ProductId);
            builder.HasMany(a => a.Categories).WithMany(a => a.Products);
            builder.HasMany(a => a.DiscountProducts).WithOne(a => a.Product).HasForeignKey(a => a.ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(a => a.TagProducts).WithOne(a => a.Product).HasForeignKey(a => a.ProductId);
            builder.HasMany(a => a.Properties).WithOne(a => a.Product).HasForeignKey(a => a.ProductId);
            builder.HasMany(a => a.Comments).WithOne(a => a.Product).HasForeignKey(a => a.ProductId);
            builder.HasMany(a => a.ProductVarients).WithOne(a => a.Product).HasForeignKey(a => a.ProductId);
            builder.HasOne(a => a.Seller).WithMany(a => a.Products).HasForeignKey(a => a.SellerId).OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(a => a.WishItems).WithOne(a => a.Product).HasForeignKey(a => a.ProductId);




            builder.Property(a => a.Stock).HasField("_Stock");



            //builder.Property(a => a.DiscountedPrice).HasValueGenerator(typeof(Asd));
            //builder.Property(a => a.DiscountedPrice).ValueGeneratedOnAddOrUpdate();
            //builder.Property(a => a.DiscountedPrice).HasField();


            //builder.Property(a => a.DiscountedPrice).HasComputedColumnSql();



            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);

        }
    }


    public class Asd : ValueGenerator<int?>
    {
        public override bool GeneratesTemporaryValues => false;

        public override int? Next(EntityEntry entry)
        {
            Console.WriteLine($"ValueGenrator is runing");
            var product = entry.Entity as Product;
            if (product != null)
            {
                Console.WriteLine($"product isnot null");
                if (product.DiscountProducts != null)
                {
                    Console.WriteLine($"product is not null");
                    Console.WriteLine($"discountedProducts is not null");

                    return product.GetDiscountedPrice1();
                }
            }
            return null;
        }
    }


}
