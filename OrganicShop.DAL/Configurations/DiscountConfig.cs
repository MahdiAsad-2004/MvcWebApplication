using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;

namespace OrganicShop.DAL.Configurations
{
    public class DiscountConfig : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {

            builder.HasMany(a => a.DiscountProducts).WithOne(a => a.Discount).HasForeignKey(a => a.DiscountId).OnDelete(DeleteBehavior.Cascade);



            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);
        }
    }
}
