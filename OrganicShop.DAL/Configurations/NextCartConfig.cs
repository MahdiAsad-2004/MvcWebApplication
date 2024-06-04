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
    public class NextCartConfig : IEntityTypeConfiguration<NextCart>
    {
        public void Configure(EntityTypeBuilder<NextCart> builder)
        {
            builder.HasMany(a => a.ProductItems).WithOne(a => a.NextCart).HasForeignKey(a => a.NextCartId);
            builder.HasOne(a => a.User).WithOne(a => a.NextCart).HasForeignKey<NextCart>(a => a.UserId).OnDelete(DeleteBehavior.Cascade);


            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);
        }
    }
}
