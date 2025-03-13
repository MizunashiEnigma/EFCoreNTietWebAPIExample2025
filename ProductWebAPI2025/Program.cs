using Tracker.WebAPIClient;
using Week8ProductModelS00237686;

namespace Week8ProductWebAPI2025S00237686
{
    public class Program
    {
        public static void Main(string[] args)
        {

            ActivityAPIClient.Track(StudentID: "S00237686", StudentName: "Tristan Cawley", activityName: "RAD30223 Week 8 Lab 1", Task: "Running Web API");

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ProductDBContext>();
            builder.Services.AddTransient<IProduct<Product>, ProductRepository>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
