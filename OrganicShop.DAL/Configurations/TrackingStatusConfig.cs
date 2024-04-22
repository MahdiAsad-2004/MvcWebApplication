

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
    public class TrackingStatusConfig : IEntityTypeConfiguration<TrackingStatus>
    {
        public void Configure(EntityTypeBuilder<TrackingStatus> builder)
        {
           

            builder.HasOne(a => a.Order).WithMany(a => a.TrackingStatuses).HasForeignKey(a => a.OrderId);



            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);
        }
    }
}
