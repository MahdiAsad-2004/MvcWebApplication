using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;

namespace OrganicShop.DAL.Configurations
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
           

            builder.HasOne(a => a.User).WithMany(a => a.Comments).HasForeignKey(a => a.UserId);
            builder.HasOne(a => a.Product).WithMany(a => a.Comments).HasForeignKey(a => a.ProductId);
            builder.HasOne(a => a.Article).WithMany(a => a.Comments).HasForeignKey(a => a.ArticleId);
            builder.HasOne(a => a.Seller).WithMany(a => a.Comments).HasForeignKey(a => a.SellerId);


            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);
        }
    }
}
