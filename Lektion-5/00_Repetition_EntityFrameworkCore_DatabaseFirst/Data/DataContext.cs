using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using _00_Repetition_EntityFrameworkCore_DatabaseFirst.Data.Entities;

namespace _00_Repetition_EntityFrameworkCore_DatabaseFirst.Data
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ContactPerson> ContactPersons { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasOne(d => d.ContactPerson)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.ContactPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Customers__Conta__25869641");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
