using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;

namespace OrganicShop.DAL.Configurations
{
    public class DeliveryConfig : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> builder)
        {


            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);
        }
    }
}
