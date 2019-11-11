using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Text;
using ZZA.Models;

namespace ZZA.Dashboard.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderItemOption> OrderItemOptions { get; set; }
        public DbSet<ProductOption> ProductOptions { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable(nameof(Customer));
            modelBuilder.Entity<Order>().ToTable(nameof(Order));
            modelBuilder.Entity<Product>().ToTable(nameof(Product));
            modelBuilder.Entity<OrderItem>().ToTable(nameof(OrderItem));
            modelBuilder.Entity<OrderItemOption>().ToTable(nameof(OrderItemOption));
            modelBuilder.Entity<ProductOption>().ToTable(nameof(ProductOption));
            modelBuilder.Entity<ProductSize>().ToTable(nameof(ProductSize));
            modelBuilder.Entity<OrderStatus>().ToTable(nameof(OrderStatus));

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

                    foreach (var fk in cascadeFKs)
                        fk.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<Customer>()
                        .Property(c => c.Id) // Client must set the ID.
                        .ValueGeneratedNever();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(ConfigurationManager.ConnectionStrings["ZZA.DB"].ConnectionString);
        }
    }
}
