using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;


namespace OrganicShop.DAL.Configurations
{
    public class UserMessageConfig : IEntityTypeConfiguration<UserMessage>
    {
        public void Configure(EntityTypeBuilder<UserMessage> builder)
        {
            builder.HasOne(a => a.User).WithMany(a => a.UserMessages).HasForeignKey(a => a.UserId);


            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);
        }
    }
}
