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
    public class TagConfig : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasMany(a => a.TagProducts).WithOne(a => a.Tag).HasForeignKey(a => a.TagId);
            builder.HasMany(a => a.TagArticles).WithOne(a => a.Tag).HasForeignKey(a => a.TagId);


            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);
        }
    }
}
