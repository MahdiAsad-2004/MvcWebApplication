using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.DAL.Configurations
{
    public class ArticleConfig : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasMany(a => a.TagArticles).WithOne(a => a.Article).HasForeignKey(a => a.ArticleId);
            builder.HasOne(a => a.Category).WithMany(a => a.Articles).HasForeignKey(a => a.CategoryId);
            builder.HasOne(a => a.User).WithMany(a => a.Articles).HasForeignKey(a => a.UserId);
            builder.HasMany(a => a.Pictures).WithOne(a => a.Article).HasForeignKey(a => a.ArticleId);
            builder.HasMany(a => a.Comments).WithOne(a => a.Article).HasForeignKey(a => a.ArticleId);


            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);
        }
    }
}
