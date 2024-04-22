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
    public class TagProductsConfig : IEntityTypeConfiguration<TagProducts>
    {
        public void Configure(EntityTypeBuilder<TagProducts> builder)
        {

            builder.HasOne(a => a.Tag).WithMany(a => a.TagProducts).HasForeignKey(a => a.TagId);
            builder.HasOne(a => a.Product).WithMany(a => a.TagProducts).HasForeignKey(a => a.ProductId);

            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);
        }
    }
}
