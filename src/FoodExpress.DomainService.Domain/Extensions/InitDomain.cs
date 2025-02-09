using FoodExpress.DomainService.Domain.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FoodExpress.DomainService.Domain.Extensions
{
    public static class InitDomain
    {
        public static IServiceCollection Initialize(this IServiceCollection services, string connectionString, string migrationAssembly)
        {
            services.AddDbContext<FoodExpressDbContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), x => x.MigrationsAssembly(migrationAssembly))
                .EnableSensitiveDataLogging()
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            });

            return services;
        }
    }
}
