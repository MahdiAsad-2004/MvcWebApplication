using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Entities.Relations;

namespace OrganicShop.DAL.Configurations
{
    public class CouponProductsConfig : IEntityTypeConfiguration<CouponProducts>
    {
        public void Configure(EntityTypeBuilder<CouponProducts> builder)
        {
           
            builder.HasOne(a => a.Coupon).WithMany(a => a.CouponProducts).HasForeignKey(a => a.CouponId);
            builder.HasOne(a => a.Product).WithMany(a => a.CouponProducts).HasForeignKey(a => a.ProductsId);



            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);
        }
    }
}
