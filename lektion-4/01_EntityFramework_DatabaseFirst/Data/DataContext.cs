using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using _01_EntityFramework_DatabaseFirst.Data.Entities;

namespace _01_EntityFramework_DatabaseFirst.Data
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

        public virtual DbSet<CategoryEntity> CategoryEntities { get; set; } = null!;
        public virtual DbSet<CurrencyEntity> CurrencyEntities { get; set; } = null!;
        public virtual DbSet<PriceListEntity> PriceListEntities { get; set; } = null!;
        public virtual DbSet<ProductEntity> ProductEntities { get; set; } = null!;
        public virtual DbSet<SkuEntity> SkuEntities { get; set; } = null!;
        public virtual DbSet<SubCategoryEntity> SubCategoryEntities { get; set; } = null!;
        public virtual DbSet<VendorEntity> VendorEntities { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryEntity>(entity =>
            {
                entity.ToTable("CategoryEntity");

                entity.HasIndex(e => e.Name, "UQ__Category__737584F6271A2E8E")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<CurrencyEntity>(entity =>
            {
                entity.HasKey(e => e.CurrencyCode)
                    .HasName("PK__Currency__408426BEADF2D37C");

                entity.ToTable("CurrencyEntity");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Country).HasMaxLength(250);

                entity.Property(e => e.Currency).HasMaxLength(250);
            });

            modelBuilder.Entity<PriceListEntity>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__PriceLis__B40CC6CD5588E69B");

                entity.ToTable("PriceListEntity");

                entity.Property(e => e.ProductId).ValueGeneratedNever();

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.CurrencyCodeNavigation)
                    .WithMany(p => p.PriceListEntities)
                    .HasForeignKey(d => d.CurrencyCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PriceList__Curre__46E78A0C");

                entity.HasOne(d => d.Product)
                    .WithOne(p => p.PriceListEntity)
                    .HasForeignKey<PriceListEntity>(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PriceList__Produ__45F365D3");
            });

            modelBuilder.Entity<ProductEntity>(entity =>
            {
                entity.ToTable("ProductEntity");

                entity.Property(e => e.Barcode)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.ProductEntities)
                    .HasForeignKey(d => d.SubCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductEn__SubCa__4222D4EF");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.ProductEntities)
                    .HasForeignKey(d => d.VendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductEn__Vendo__4316F928");
            });

            modelBuilder.Entity<SkuEntity>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__SkuEntit__B40CC6CD5919DA7E");

                entity.ToTable("SkuEntity");

                entity.Property(e => e.ProductId).ValueGeneratedNever();

                entity.HasOne(d => d.Product)
                    .WithOne(p => p.SkuEntity)
                    .HasForeignKey<SkuEntity>(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SkuEntity__Produ__49C3F6B7");
            });

            modelBuilder.Entity<SubCategoryEntity>(entity =>
            {
                entity.ToTable("SubCategoryEntity");

                entity.HasIndex(e => e.Name, "UQ__SubCateg__737584F66730E842")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SubCategoryEntities)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SubCatego__Categ__3F466844");
            });

            modelBuilder.Entity<VendorEntity>(entity =>
            {
                entity.ToTable("VendorEntity");

                entity.HasIndex(e => e.Name, "UQ__VendorEn__737584F68061DCCD")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
