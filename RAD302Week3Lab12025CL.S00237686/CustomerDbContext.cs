using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.WebAPIClient;

namespace RAD302Week3Lab12025CL.S00237686
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public CustomerDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

           // ActivityAPIClient.Track(StudentID: "S00237686", StudentName: "Tristan Cawley", activityName: "Rad302 Week 3 Lab 1", Task: "Creating Customer DB Schema");

            var connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = CustomerCoreDB";
            optionsBuilder.UseSqlServer(connectionString)
                .LogTo(Console.WriteLine,
                new[] { DbLoggerCategory.Database.Command.Name },
                LogLevel.Information);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ActivityAPIClient.Track(StudentID: "S00237686", StudentName: "Tristan Cawley", activityName: "Rad302 Week 3 Lab 1", Task: "Creating Customer DB Schema");

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                ID = 1,
                Name = "Patricia McKenna",
                Address = "8 Johnstown Road, Cork",
                CreditRating = 200.00f

            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                ID = 2,
                Name = "Helen Bennett",
                Address = "Garden House Crowther Way, Dublin",
                CreditRating = 400.00f

            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                ID = 3,
                Name = "Yoshi Tanami",
                Address = "1900 Oak St., Vancouver",
                CreditRating = 2000.00f

            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                ID = 4,
                Name = "John Steel",
                Address = "12 Orchestra Terrace, Dublin 20",
                CreditRating = 800.00f

            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                ID = 5,
                Name = "Catherine Dewey",
                Address = "Rue Joseph-Bens 532, Brussels",
                CreditRating = 600.00f

            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
