using _03_WebApi_WithApiKey.Models.Entitites;
using Microsoft.EntityFrameworkCore;

namespace _03_WebApi_WithApiKey.Models.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public virtual DbSet<ProductEntity> Products { get; set; } = null!;
    
    }
}
