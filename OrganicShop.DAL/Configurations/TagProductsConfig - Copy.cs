using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Entities.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.DAL.Configurations
{
    public class TagArticlesConfig : IEntityTypeConfiguration<TagArticles>
    {
        public void Configure(EntityTypeBuilder<TagArticles> builder)
        {

            builder.HasOne(a => a.Tag).WithMany(a => a.TagArticles).HasForeignKey(a => a.TagId);
            builder.HasOne(a => a.Article).WithMany(a => a.TagArticles).HasForeignKey(a => a.ArticleId);

            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);
        }
    }
}
