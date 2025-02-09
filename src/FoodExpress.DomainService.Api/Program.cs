
using FoodExpress.DomainService.Api.Services;
using FoodExpress.DomainService.Domain.Extensions;

namespace FoodExpress.DomainService.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                //.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // TODO: move to separate init
            builder.Services.AddTransient<IOrderService, OrderService>();
            builder.Services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            // TODO: move to settings
            var connectionString = builder.Configuration.GetConnectionString("LocalDb");
            var migrationAssembly = "FoodExpress.DomainService.Api";

            InitDomain.Initialize(builder.Services, connectionString, migrationAssembly);

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
