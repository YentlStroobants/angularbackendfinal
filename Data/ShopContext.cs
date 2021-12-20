using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularChallengeAPI.Models;

namespace AngularChallengeAPI.Data
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        { }

        public DbSet<NonFood> NonFoods { get; set; }
        public DbSet <Food> Foods { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }     
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<NonFood>().ToTable("NonFood");
        //    modelBuilder.Entity<Food>().ToTable("Food");
        //    modelBuilder.Entity<Product>().ToTable("Product");
        //    modelBuilder.Entity<Role>().ToTable("Role");
        //    modelBuilder.Entity<User>().ToTable("User");
        //    modelBuilder.Entity<Status>().ToTable("Status");
        //    modelBuilder.Entity<Order>().ToTable("Order");
        //    modelBuilder.Entity<OrderProduct>().ToTable("OrderProduct");        
        //}
    }
}
