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
    public class DiscountProductsConfig : IEntityTypeConfiguration<DiscountProducts>
    {
        public void Configure(EntityTypeBuilder<DiscountProducts> builder)
        {


            builder.HasOne(a => a.Discount).WithMany(a => a.DiscountProducts).HasForeignKey(a => a.DiscountId);
            builder.HasOne(a => a.Product).WithMany(a => a.DiscountProducts).HasForeignKey(a => a.ProductId);



            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);
        }
    }
}
