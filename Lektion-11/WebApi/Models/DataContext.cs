using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public virtual DbSet<CategoryEntity> Categories { get; set; } = null!;
        public virtual DbSet<ProductEntity> Products { get; set; } = null!;
        public virtual DbSet<CustomerEntity> Customers { get; set; } = null!;
    }
}
