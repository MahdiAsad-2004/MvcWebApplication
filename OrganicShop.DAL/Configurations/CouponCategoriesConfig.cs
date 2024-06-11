using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Entities.Relations;

namespace OrganicShop.DAL.Configurations
{
    public class CouponCategoriesConfig : IEntityTypeConfiguration<CouponCategories>
    {
        public void Configure(EntityTypeBuilder<CouponCategories> builder)
        {
           
            builder.HasOne(a => a.Coupon).WithMany(a => a.CouponCategories).HasForeignKey(a => a.CouponId);
            builder.HasOne(a => a.Category).WithMany(a => a.CouponCategories).HasForeignKey(a => a.CategoryId);



            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);
        }
    }
}
