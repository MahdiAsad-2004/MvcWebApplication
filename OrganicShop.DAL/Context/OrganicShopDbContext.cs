using Microsoft.EntityFrameworkCore;
using OrganicShop.DAL.Configurations;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Entities.Relations;

namespace OrganicShop.DAL.Context
{
    public class OrganicShopDbContext : DbContext
    {
        #region db set

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<BankCard> BankCards { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<DiscountCategories> DiscountCategories { get; set; }
        public DbSet<DiscountProducts> DiscountProducts { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<TrackingStatus> TrackingStatuses { get; set; }
        public DbSet<TrackingDescription> TrackingDescriptions { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionUsers> PermissionUsers { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Picture> ProductImages { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagProducts> TagProducts { get; set; }
        public DbSet<TagArticles> TagArticles { get; set; }
        public DbSet<UnitValue> Units { get; set; }
        public DbSet<User> Users { get; set; }

        #endregion


        public OrganicShopDbContext(DbContextOptions<OrganicShopDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Owned<BaseEntity>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfig).Assembly);

        }



    }

}
