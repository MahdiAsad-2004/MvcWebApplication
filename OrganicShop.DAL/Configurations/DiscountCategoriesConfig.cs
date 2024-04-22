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
    public class DiscountCategoriesConfig : IEntityTypeConfiguration<DiscountCategories>
    {
        public void Configure(EntityTypeBuilder<DiscountCategories> builder)
        {
           
            builder.HasOne(a => a.Discount).WithMany(a => a.DiscountCategories).HasForeignKey(a => a.DiscountId);
            builder.HasOne(a => a.Category).WithMany(a => a.DiscountCategories).HasForeignKey(a => a.CategoryId);



            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);
        }
    }
}
