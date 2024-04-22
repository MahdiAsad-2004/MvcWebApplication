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
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
           

            builder.HasOne(a => a.User).WithMany(a => a.Comments).HasForeignKey(a => a.UserId);
            builder.HasOne(a => a.Product).WithMany(a => a.Comments).HasForeignKey(a => a.ProductId);


            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);
        }
    }
}
