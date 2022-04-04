using _00_Repetition_WebApiKey.Models.Entitites;
using Microsoft.EntityFrameworkCore;

namespace _00_Repetition_WebApiKey.Models.Data
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
