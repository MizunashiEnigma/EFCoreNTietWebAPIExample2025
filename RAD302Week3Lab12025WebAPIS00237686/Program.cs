
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RAD302Week3Lab12025CL.S00237686;
using RAD302Week3Lab12025WebAPIS00237686.Controllers;
using RAD302Week3Lab12025WebAPIS00237686.DataLayer;
using System.Security.Cryptography.Xml;
using System.Text;
using Tracker.WebAPIClient;

namespace RAD302Week3Lab12025WebAPIS00237686
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ActivityAPIClient.Track(StudentID: "S00237686", StudentName: "Tristan Cawley", activityName: "Rad302 Week 4 2025 Lab 1", Task: "testing Authorization");

            var builder = WebApplication.CreateBuilder(args);

            //var connectionString = builder.Configuration.GetConnectionString("Week4ConnectionString")
            //    ?? throw new InvalidOperationException("Connection string 'Week4ConnectionString' not found.");

            // adding user identity class  
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<ApplicationDbContext>();

            //add Authentication to the Web App
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddCookie().AddJwtBearer(cfg =>
            {
                cfg.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["Tokens:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["Tokens:Audience"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Tokens:Key"]))
                };
            });

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
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "RAD302Week3Lab12025WebAPIS00237686", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization Header using Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        }, new String[]{}
                    }
                });
            });
            
            
            
            /////////////////////////////////
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var _ctx = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var userManager = scope.ServiceProvider.GetRequiredService < UserManager<ApplicationUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                _ctx.Database.Migrate();

                ApplicationDbSeeder dbSeeder = new ApplicationDbSeeder(_ctx, userManager, roleManager);
                dbSeeder.Seed().Wait();
            }

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        } //however i can confirm that week3 worked, before i added the week 4 things. I saw the swagger UI and was even able totest end+points.
    }
}
