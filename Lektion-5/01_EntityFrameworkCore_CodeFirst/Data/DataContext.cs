using _01_EntityFrameworkCore_CodeFirst.Data.Entitites;
using Microsoft.EntityFrameworkCore;

namespace _01_EntityFrameworkCore_CodeFirst.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public virtual DbSet<ContactPersonEntity> ContactPeople { get; set; }
        public virtual DbSet<CustomerEntity> Customers { get; set; }
    }
}
