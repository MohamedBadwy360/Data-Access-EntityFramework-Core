using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderWithDetailsView> OrderWithDetailsViews { get; set; }
        public DbSet<OrderBill> OrderBills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .ToTable("Products", schema: "Inventory")
                .HasKey(p => p.Id);

            modelBuilder.Entity<Order>()
                .ToTable("Orders", schema: "Sales")
                .HasKey(o => o.Id);

            modelBuilder.Entity<OrderDetail>()
                .ToTable("OrderDetails", schema: "Sales")
                .HasKey(od => od.Id);

            //modelBuilder.HasDefaultSchema("Sales");

            modelBuilder.Entity<OrderWithDetailsView>()
                .ToView("OrderWithDetailsView")
                .HasNoKey();

            modelBuilder.Entity<OrderBill>()
                .HasNoKey()
                .ToFunction("GetOrderBill");

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultString")!;

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
