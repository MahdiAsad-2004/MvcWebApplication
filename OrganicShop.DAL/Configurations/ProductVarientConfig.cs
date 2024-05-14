using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;

namespace OrganicShop.DAL.Configurations
{
    public class ProductVarientConfig : IEntityTypeConfiguration<ProductVarient>
    {
        public void Configure(EntityTypeBuilder<ProductVarient> builder)
        {
            builder.HasOne(a => a.Product).WithMany(a => a.ProductVarients).HasForeignKey(a => a.ProductId);


            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);
        }
    }
}
