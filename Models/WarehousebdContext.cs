using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Warehouse.Models;

public partial class WarehousebdContext : DbContext
{
    public WarehousebdContext()
    {
    }

    public WarehousebdContext(DbContextOptions<WarehousebdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BalanceProduct> BalanceProducts { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<Shipment> Shipments { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=Warehousebd; Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BalanceProduct>(entity =>
        {
            entity.ToTable("BalanceProduct");

            entity.Property(e => e.BalanceProductId).HasColumnName("BalanceProduct_id");
            entity.Property(e => e.ProductId).HasColumnName("Product_id");

            entity.HasOne(d => d.Product).WithMany(p => p.BalanceProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BalanceProduct_Product");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("Client");

            entity.Property(e => e.ClientId).HasColumnName("Client_id");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.NumberPhone).HasMaxLength(12);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId).HasColumnName("Employee_id");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Fio)
                .HasMaxLength(100)
                .HasColumnName("FIO");
            entity.Property(e => e.NumberPhone).HasMaxLength(12);
            entity.Property(e => e.Pasport).HasMaxLength(10);
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.ToTable("Manager");

            entity.Property(e => e.ManagerId).HasColumnName("Manager_id");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Fio)
                .HasMaxLength(150)
                .HasColumnName("FIO");
            entity.Property(e => e.NumberPhone).HasMaxLength(12);
            entity.Property(e => e.Pasport).HasMaxLength(10);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("Product_id");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.ProductTypeId).HasColumnName("ProductType_id");

            entity.HasOne(d => d.ProductType).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_ProductType");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.ProductTypyId);

            entity.ToTable("ProductType");

            entity.Property(e => e.ProductTypyId).HasColumnName("ProductTypy_id");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => new { e.NumberProvider, e.ProductId }).HasName("PK_Provider_1");

            entity.ToTable("Provider");

            entity.Property(e => e.NumberProvider).HasMaxLength(50);
            entity.Property(e => e.ProductId).HasColumnName("Product_id");
            entity.Property(e => e.EmployeeId).HasColumnName("Employee_id");
            entity.Property(e => e.ShipmentId).HasColumnName("Shipment_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.Providers)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Provider_Employee");

            entity.HasOne(d => d.EmployeeNavigation).WithMany(p => p.Providers)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Provider_Shipment");

            entity.HasOne(d => d.Product).WithMany(p => p.Providers)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Provider_Product");
        });

        modelBuilder.Entity<Shipment>(entity =>
        {
            entity.ToTable("Shipment");

            entity.Property(e => e.ShipmentId).HasColumnName("Shipment_id");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.NumberPhone).HasMaxLength(12);
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => new { e.NumberSupplier, e.ProductId }).HasName("PK_Supplier_1");

            entity.ToTable("Supplier");

            entity.Property(e => e.NumberSupplier).HasMaxLength(100);
            entity.Property(e => e.ProductId).HasColumnName("Product_id");
            entity.Property(e => e.ClientId).HasColumnName("Client_id");
            entity.Property(e => e.ManagerId).HasColumnName("Manager_id");

            entity.HasOne(d => d.Client).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Supplier_Client");

            entity.HasOne(d => d.Manager).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.ManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Supplier_Manager");

            entity.HasOne(d => d.Product).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Supplier_Product");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
