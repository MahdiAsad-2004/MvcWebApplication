using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;


namespace OrganicShop.DAL.Configurations
{
    public class PropertyTypeConfig : IEntityTypeConfiguration<PropertyType>
    {
        public void Configure(EntityTypeBuilder<PropertyType> builder)
        {

            builder.HasMany(a => a.Properties).WithOne(a => a.PropertyType).HasForeignKey(a => a.TypeId).OnDelete(DeleteBehavior.Cascade);



            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);
        }
    }
}
