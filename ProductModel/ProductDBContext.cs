
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Week8ProductModelS00237686
{
    public class ProductDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<GrnLine> GrnLines { get; set; }
        public DbSet<GRN> GRNs { get; set; }

        static public bool inProduction;
        public ProductDBContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var myconnectionstring = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Week8ProductCoreDB-2025-S00237686";
            optionsBuilder.UseSqlServer(myconnectionstring)
              .LogTo(Console.WriteLine,
                     new[] { DbLoggerCategory.Database.Command.Name },
                     LogLevel.Information);
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // NOTE: this line is activated from the bin folder whihc is a sub
            // folder of the class library project
            // You must build the project before calling Add-migration
            if (!inProduction)
            {
                Product[] products = DBHelper.Get<Product>(@"..\ProductModel\Products.csv").ToArray();
                GRN[] gRNs = DBHelper.Get<GRN>(@"..\ProductModel\GRN with Headings.csv").ToArray();
                GrnLine[] gRNLines = DBHelper.Get<GrnLine>(@"..\ProductModel\GRN lines with Headings.csv").ToArray();
               
                modelBuilder.Entity<Product>().HasData(products);
                modelBuilder.Entity<GRN>().HasData(gRNs);
                modelBuilder.Entity<GrnLine>().HasData(gRNLines);
            }
            //modelBuilder.Entity<Product>().HasData(
            // new Product
            // {
            //     ID = 46,
            //     Description = "test",
            //     ReorderLevel = 4,
            //     ReorderQuantity = 2,
            //     StockOnHand = 30,
            //     UnitPrice = 10
            // });

            base.OnModelCreating(modelBuilder);
        }


    }
}


