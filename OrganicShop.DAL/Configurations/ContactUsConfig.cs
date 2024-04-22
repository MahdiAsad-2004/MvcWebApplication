using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;

namespace OrganicShop.DAL.Configurations
{
    public class CantactUsConfig : IEntityTypeConfiguration<ContactUs>
    {
        public void Configure(EntityTypeBuilder<ContactUs> builder)
        {
          


            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);


            builder.HasData(new ContactUs
            {
                Id = 1,
                Address = "Address",
                ShortDescription = "ShorDescriptions",
                Description = "Descriptions",
                Email1 = "OrganicShop@gmail.com",
                Email2 = null,
                Phone1 = "02134658899",
                Phone2 = null,
                Phone3 = null,
                PhoneNumber1 = "09121234455",
                PhoneNumber2 = null,
                PhoneNumber3 = null,
                Office1 = "Tehran",
                Office2 = null,
                Office3 = null,
            });



            builder.OwnsOne(a => a.BaseEntity).HasData(new
            {
                ContactUsId = (byte)1,
                CreateDate = DateTime.Now,
                LastModified = DateTime.Now,
                IsActive = true,
                IsDelete = false,

            });
         


        }
    }
}
