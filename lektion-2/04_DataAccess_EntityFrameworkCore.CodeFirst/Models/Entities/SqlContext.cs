using Microsoft.EntityFrameworkCore;

namespace _04_DataAccess_EntityFrameworkCore.CodeFirst.Models.Entities
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {

        }

        public SqlContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<CategoryEntity> Categories { get; set; }
    }
}
