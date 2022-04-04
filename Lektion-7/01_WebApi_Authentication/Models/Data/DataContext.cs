using _01_WebApi_Authentication.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace _01_WebApi_Authentication.Models.Data
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
        public virtual DbSet<UserEntity> Users { get; set; } = null!;
    }
}
