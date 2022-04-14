using Microsoft.EntityFrameworkCore;
using WebApi.Models.Order;
using WebApi.Models.Product;

namespace WebApi.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {

        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public virtual DbSet<ProductCategoryEntity> ProductCategories { get; set; } = null!;
        public virtual DbSet<ProductEntity> Products { get; set; } = null!;
        public virtual DbSet<OrderEntity> Orders { get; set; } = null!;
        public virtual DbSet<OrderRowEntity> OrderRows { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderRowEntity>()
                .HasKey(c => new { c.OrderId, c.ArticleNumber });

        }
    }
}
