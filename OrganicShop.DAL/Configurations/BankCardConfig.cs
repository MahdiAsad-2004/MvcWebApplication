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
    public class BankCardConfig : IEntityTypeConfiguration<BankCard>
    {
        public void Configure(EntityTypeBuilder<BankCard> builder)
        {
           



            builder.HasOne(a => a.User).WithMany(a => a.BankCards).HasForeignKey(a => a.UserId);




            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);
        }
    }
}
