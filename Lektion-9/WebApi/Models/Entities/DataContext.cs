﻿using Microsoft.EntityFrameworkCore;

namespace WebApi.Models.Entities
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public virtual DbSet<UserEntity> Users { get; set; } = null!;
        public virtual DbSet<ProductEntity> Products { get; set; } = null!;
    }
}
