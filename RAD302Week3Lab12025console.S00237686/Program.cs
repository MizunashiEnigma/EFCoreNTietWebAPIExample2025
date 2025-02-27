using RAD302Week3Lab12025CL.S00237686;
using Tracker.WebAPIClient;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace RAD302Week3Lab12025console.S00237686
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ActivityAPIClient.Track(StudentID: "S00237686", StudentName: "Tristan Cawley",
                activityName: "Rad302 Week 3 Lab 1", Task: "Testing Console Queries against the DBModel");

            List<Customer> customerModel = new List<Customer>();

            using (CustomerDbContext db = new CustomerDbContext())
            {
                Console.WriteLine("All Customers:");
                var listAllCustomers = from c in db.Customer
                                       select c;

                foreach (var c in listAllCustomers)
                {
                    Console.WriteLine($"ID: {c.ID}, Name: {c.Name}, Address: {c.Address}, Credit Rating: {c.CreditRating}");
                }
                Console.WriteLine("\nCustomers with Credit Rating greater than 400:");
                var highCreditCustomers = from c in db.Customer
                                          where c.CreditRating > 400
                                          select c;

                foreach (var c in highCreditCustomers)
                {
                    Console.WriteLine($"ID: {c.ID}, Name: {c.Name}, Credit Rating: {c.CreditRating}");
                }

                Console.WriteLine("\nAdding a new customer...");
                int maxId = db.Customer.Max(c => c.ID);

                Customer newCustomer = new Customer
                {
                    ID = maxId + 1,
                    Name = "New Customer",
                    Address = "123 New Street, City",
                    CreditRating = 500.0f
                };

                db.Customer.Add(newCustomer);
                db.SaveChanges();
                Console.WriteLine($"New customer added with ID: {newCustomer.ID}");
            }

            Console.WriteLine("\nOperation completed. Press any key to exit.");
            Environment.Exit(0);
        }

    }
}
