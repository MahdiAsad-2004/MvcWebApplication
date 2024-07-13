//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using OrganicShop.Domain.Entities.Base;
//using OrganicShop.Domain.Entities.Relations;

//namespace OrganicShop.DAL.Configurations
//{
//    public class CateoryProductsConfig : IEntityTypeConfiguration<CategoryProducts>
//    {
//        public void Configure(EntityTypeBuilder<CategoryProducts> builder)
//        {
           
//            builder.HasOne(a => a.Category).WithMany(a => a.CategoryProducts).HasForeignKey(a => a.CategoryId);
//            builder.HasOne(a => a.Product).WithMany(a => a.CategoryProducts).HasForeignKey(a => a.ProductId);



//            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);
//        }
//    }
//}
