
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RAD302Week3Lab12025CL.S00237686;
using RAD302Week3Lab12025WebAPIS00237686.Controllers;
using RAD302Week3Lab12025WebAPIS00237686.DataLayer;
using Tracker.WebAPIClient;

namespace RAD302Week3Lab12025WebAPIS00237686
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ActivityAPIClient.Track(StudentID: "S00237686", StudentName: "Tristan Cawley", activityName: "Rad302 Week 4 2025 Lab 1", Task: "Implementing Authentication Context Model");

            var builder = WebApplication.CreateBuilder(args);

            //var connectionString = builder.Configuration.GetConnectionString("Week4ConnectionString")
            //    ?? throw new InvalidOperationException("Connection string 'Week4ConnectionString' not found.");

            // adding user identity class  
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<ApplicationDbContext>();

            // Add services to the container.
            builder.Services.AddDbContext<CustomerDbContext>();
            builder.Services.AddTransient<ICustomer<Customer>, CustomerRepository>();
            
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Week4ConnectionString"));
            });
               
           
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

           
            
            
            
            /////////////////////////////////
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
