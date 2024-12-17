using LibraryManagementSystem.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagementSystem.Services.Extensions
{
    public static class ServiceConfigurationExtensions
    {
        public static IServiceCollection AddServicesAndConfigs(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}