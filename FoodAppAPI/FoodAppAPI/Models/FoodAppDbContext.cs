using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FoodAppAPI.Models;

public partial class FoodAppDbContext : DbContext
{
    public FoodAppDbContext()
    {
    }

    public FoodAppDbContext(DbContextOptions<FoodAppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Cartitem> Cartitems { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Deliverer> Deliverers { get; set; }

    public virtual DbSet<Dish> Dishes { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Orderitem> Orderitems { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=FoodAppDB;User=root;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddrId).HasName("PRIMARY");

            entity.Property(e => e.Line2).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Line3).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Pin).IsFixedLength();
        });

        modelBuilder.Entity<Cartitem>(entity =>
        {
            entity.HasKey(e => new { e.CustId, e.RId, e.DId }).HasName("PRIMARY");

            entity.Property(e => e.DQn).HasDefaultValueSql("'1'");

            entity.HasOne(d => d.Cust).WithMany(p => p.Cartitems)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("cartitems_ibfk_1");

            entity.HasOne(d => d.DIdNavigation).WithMany(p => p.Cartitems)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("cartitems_ibfk_3");

            entity.HasOne(d => d.RIdNavigation).WithMany(p => p.Cartitems)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("cartitems_ibfk_2");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CatId).HasName("PRIMARY");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CId).HasName("PRIMARY");

            entity.Property(e => e.CAddr).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.CName).HasDefaultValueSql("'NULL'");

            entity.HasOne(d => d.CAddrNavigation).WithMany(p => p.Customers)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("customers_ibfk_1");
        });

        modelBuilder.Entity<Deliverer>(entity =>
        {
            entity.HasKey(e => e.DId).HasName("PRIMARY");

            entity.Property(e => e.DAddr).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.DName).HasDefaultValueSql("'NULL'");

            entity.HasOne(d => d.DAddrNavigation).WithMany(p => p.Deliverers)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("deliverers_ibfk_1");
        });

        modelBuilder.Entity<Dish>(entity =>
        {
            entity.HasKey(e => e.DId).HasName("PRIMARY");

            entity.HasOne(d => d.DCategNavigation).WithMany(p => p.Dishes)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("dishes_ibfk_1");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => new { e.RId, e.DId }).HasName("PRIMARY");

            entity.HasOne(d => d.DIdNavigation).WithMany(p => p.Menus)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("menus_ibfk_1");

            entity.HasOne(d => d.RIdNavigation).WithMany(p => p.Menus)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("menus_ibfk_2");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OId).HasName("PRIMARY");

            entity.Property(e => e.OId).HasDefaultValueSql("'uuid()'");
            entity.Property(e => e.ODate).HasDefaultValueSql("'curtime()'");
            entity.Property(e => e.Status).HasDefaultValueSql("'''Pending'''");

            entity.HasOne(d => d.CIdNavigation).WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("orders_ibfk_2");

            entity.HasOne(d => d.RIdNavigation).WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("orders_ibfk_1");
        });

        modelBuilder.Entity<Orderitem>(entity =>
        {
            entity.HasKey(e => new { e.CustId, e.RId, e.DId }).HasName("PRIMARY");

            entity.Property(e => e.DQn).HasDefaultValueSql("'1'");

            entity.HasOne(d => d.Cust).WithMany(p => p.Orderitems)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("orderitems_ibfk_1");

            entity.HasOne(d => d.DIdNavigation).WithMany(p => p.Orderitems)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("orderitems_ibfk_3");

            entity.HasOne(d => d.OIdNavigation).WithMany(p => p.Orderitems)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("orderitems_ibfk_4");

            entity.HasOne(d => d.RIdNavigation).WithMany(p => p.Orderitems)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("orderitems_ibfk_2");
        });

        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.HasKey(e => e.RId).HasName("PRIMARY");

            entity.Property(e => e.RAddr).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.RName).HasDefaultValueSql("'NULL'");

            entity.HasOne(d => d.RAddrNavigation).WithMany(p => p.Restaurants)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("restaurants_ibfk_1");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.TId).HasName("PRIMARY");

            entity.Property(e => e.TId).HasDefaultValueSql("'uuid()'");
            entity.Property(e => e.Name).HasDefaultValueSql("'NULL'");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
