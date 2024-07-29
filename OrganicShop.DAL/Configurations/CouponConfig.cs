using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;

namespace OrganicShop.DAL.Configurations
{
    public class CouponConfig : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {

            builder.HasMany(a => a.CouponCategories).WithOne(a => a.Coupon).HasForeignKey(a => a.CouponId).OnDelete(DeleteBehavior.Cascade);



            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);
        }
    }
}
