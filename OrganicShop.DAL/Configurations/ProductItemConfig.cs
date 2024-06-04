using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;

namespace OrganicShop.DAL.Configurations
{
    public class ProductItemConfig : IEntityTypeConfiguration<ProductItem>
    {
        public void Configure(EntityTypeBuilder<ProductItem> builder)
        {
            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);
          

            builder.HasOne(a => a.Product).WithMany(a => a.ProductItems).HasForeignKey(a => a.ProductId);
            builder.HasOne(a => a.Cart).WithMany(a => a.ProductItems).HasForeignKey(a => a.CartId);
            builder.HasOne(a => a.NextCart).WithMany(a => a.ProductItems).HasForeignKey(a => a.NextCartId);
            builder.HasOne(a => a.Order).WithMany(a => a.ProductItems).HasForeignKey(a => a.OrderId);


        }
    }
}
