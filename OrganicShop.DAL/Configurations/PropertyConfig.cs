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
    public class PropertyConfig : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.HasOne(a => a.Product).WithMany(a => a.Properties).HasForeignKey(a => a.ProductId);
            builder.HasOne(a => a.Base).WithMany(a => a.Childs).HasForeignKey(a => a.BaseId);


            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);
        }
    }
}
