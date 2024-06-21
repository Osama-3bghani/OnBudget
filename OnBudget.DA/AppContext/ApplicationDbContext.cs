using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using OnBudget.DA.Model.Entities;

namespace OnBudget.DA.AppContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = OSAMA-LAPTOP\\SQLEXPRESS; Initial Catalog = OnBudgett; Integrated Security = true ; Encrypt = false");
            }
            //"Data Source = SQL8010.site4now.net;Initial Catalog=db_aa8533_onbudget;User Id=db_aa8533_onbudget_admin;Password=onbudget-1"
            //optionsBuilder.UseSqlServer("Data Source = OSAMA-LAPTOP\\SQLEXPRESS; Initial Catalog = OnBudget; Integrated Security = true ; Encrypt = false");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.OrderId);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(op => op.ProductId);

            modelBuilder.Entity<OrderProduct>()
                .Property(op => op.Quantity)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Order>()
        //        .HasMany(o => o.Products)
        //        .WithMany(p => p.Orders)
        //        .UsingEntity(j => j.ToTable("OrderProduct"));

        //    base.OnModelCreating(modelBuilder);
        //}

        //public DbSet<Bill> Bills { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
   

    }
}
