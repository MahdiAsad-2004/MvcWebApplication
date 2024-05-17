using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;

namespace OrganicShop.DAL.Configurations
{
    public class SellerConfig : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
          
            builder.HasOne(a => a.User).WithOne(a => a.Seller).HasForeignKey<Seller>(a => a.UserId);
            builder.HasOne(a => a.Picture).WithOne(a => a.Seller).HasForeignKey<Picture>(a => a.SellerId);
            builder.HasOne(a => a.Address).WithOne(a => a.Seller).HasForeignKey<Address>(a => a.SellerId);
            builder.HasMany(a => a.Products).WithOne(a => a.Seller).HasForeignKey(a => a.SellerId);
            builder.HasMany(a => a.Comments).WithOne(a => a.Seller).HasForeignKey(a => a.SellerId);


            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);
        }
    }
}
