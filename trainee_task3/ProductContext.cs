using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using trainee_task3.Models;

namespace trainee_task3
{
    public partial class ProductContext:DbContext
    {
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public ProductContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-DNTJVMH;Database=ProductsDB;Trusted_Connection=True;");
        }
    }
}
