using FoodExpress.DomainService.Domain.Constants;
using FoodExpress.DomainService.Domain.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodExpress.DomainService.Domain.Context
{
    public class FoodExpressDbContext : DbContext
    {
        public DbSet<MenuCategory> MenuCategories { get; set; }

        public DbSet<MenuPosition> MenuPositions { get; set; }

        public DbSet<MenuPositionProduct> MenuPositionProducts { get; set; }

        public DbSet<MenuSubcategory> MenuSubcategories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<OrderItemDetails> OrderItemDetails { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductGroup> ProductGroups { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public FoodExpressDbContext(DbContextOptions<FoodExpressDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OverrideDefaultTypes(modelBuilder);

            OnModelCreating(modelBuilder.Entity<MenuCategory>());
            OnModelCreating(modelBuilder.Entity<MenuPosition>());
            OnModelCreating(modelBuilder.Entity<MenuSubcategory>());
            OnModelCreating(modelBuilder.Entity<Product>());
            OnModelCreating(modelBuilder.Entity<ProductGroup>());

            base.OnModelCreating(modelBuilder);
        }

        private void OnModelCreating<T>(EntityTypeBuilder<T> builder) where T: BaseDescriptiveNameEntity
        {
            builder.Property(x => x.Name).HasMaxLength(MySqlConstants.SHORT_NAME_MAX_LENGTH);
            builder.Property(x => x.Description).HasMaxLength(MySqlConstants.DESCRIPTION_MAX_LENGTH);
        }

        private void OverrideDefaultTypes(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(Nullable<DateTime>))
                    {
                        property.SetColumnType(MySqlConstants.DATETIME_0_DEF);
                    }

                    if (property.ClrType == typeof(decimal))
                    {
                        property.SetColumnType(MySqlConstants.DECIMAL_182_DEF);
                    }
                }
            }
        }
    }
}
