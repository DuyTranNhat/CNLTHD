using System;
using System.Collections.Generic;
using CNLTHD.Models;
using Microsoft.EntityFrameworkCore;

namespace CNLTHD.Data;

public partial class CnlthdDbContext : DbContext
{
    public CnlthdDbContext()
    {
    }

    public CnlthdDbContext(DbContextOptions<CnlthdDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A0B2C0FA434");

            entity.ToTable("Category");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6CDB7D19F44");

            entity.ToTable("Product");

            entity.Property(e => e.ImageUrl).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Stock).HasDefaultValue(0);


            entity.HasOne(d => d.Category)
              .WithMany(c => c.Products) 
              .HasForeignKey(d => d.CategoryId)
              .OnDelete(DeleteBehavior.Restrict) 
              .HasConstraintName("FK_Product_Category");

            entity.HasOne(d => d.Supplier)
                  .WithMany(s => s.Products) 
                  .HasForeignKey(d => d.SupplierId)
                  .OnDelete(DeleteBehavior.Restrict) 
                  .HasConstraintName("FK_Product_Supplier");
        });



        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PK__Supplier__4BE666B488650046");

            entity.ToTable("Supplier");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(15);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CC4CEB7F7EEE");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "UQ__User__A9D10534179C04F1").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .HasDefaultValue("user");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
