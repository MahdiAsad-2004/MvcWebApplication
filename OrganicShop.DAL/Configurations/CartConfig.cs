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
    public class CartConfig : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
          
            builder.HasMany(a => a.ProductItems).WithOne(a => a.Cart).HasForeignKey(a => a.CartId);
            builder.HasOne(a => a.User).WithOne(a => a.Cart).HasForeignKey<Cart>(a => a.UserId).OnDelete(DeleteBehavior.NoAction);
            //builder.HasOne(a => a.Userr).WithOne(a => a.NextCart).HasForeignKey<Cart>(a => a.UserId);


            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);
        }
    }
}
