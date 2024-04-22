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
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
          

            builder.HasMany(a => a.ProductItems).WithOne(a => a.Order).HasForeignKey(a => a.OrderId);
            builder.HasOne(a => a.Receiver).WithMany(a => a.Orders).HasForeignKey(a => a.ReceiverId);
            //builder.HasOne(a => a.Address).WithMany(a => a.Orders).HasForeignKey(a => a.AddressId);
            builder.HasMany(a => a.TrackingStatuses).WithOne(a => a.Order).HasForeignKey(a => a.OrderId);
            builder.HasMany(a => a.TrackingDescriptions).WithOne(a => a.Order).HasForeignKey(a => a.OrderId);
            builder.HasOne(a => a.Address).WithMany(a => a.Orders).HasForeignKey(a => a.AddressId);


            

            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);
        }
    }
}
