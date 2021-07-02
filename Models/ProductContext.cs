using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_2.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options)
        {
        }
        private const string connectionString = "data source=DESKTOP-DT75BB7;Database=Product;Integrated Security=SSPI;persist security info=True; ";

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.Entity<Category>().HasMany(p => p.Product).WithOne(c => c.Category);
        //     base.OnConfiguring(optionsBuilder);
        //     optionsBuilder.UseSqlServer(connectionString);
        // }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().Property(c => c.CategoryID).ValueGeneratedOnAdd();
            modelBuilder.Entity<Category>().HasMany(p => p.Products).WithOne(c => c.Category);
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryID = 1,
                CategoryName = "Category1",
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductID = 1,
                ProductName = "Product1",
                CategoryId = 1,
            });
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}