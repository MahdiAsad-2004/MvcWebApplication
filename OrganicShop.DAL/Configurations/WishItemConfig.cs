using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Entities.Relations;


namespace OrganicShop.DAL.Configurations
{
    public class WishItemConfig : IEntityTypeConfiguration<WishItem>
    {
        public void Configure(EntityTypeBuilder<WishItem> builder)
        {

            builder.HasOne(a => a.User).WithMany(a => a.WishItems).HasForeignKey(a => a.UserId);
            builder.HasOne(a => a.Product).WithMany(a => a.WishItems).HasForeignKey(a => a.ProductId);

            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);
        }
    }
}
