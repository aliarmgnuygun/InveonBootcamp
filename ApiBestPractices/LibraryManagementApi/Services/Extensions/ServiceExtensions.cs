using LibraryManagementApi.Services.Authors;
using LibraryManagementApi.Services.Books;
using LibraryManagementApi.Services.ExceptionHandlers;
using System.Reflection;

namespace LibraryManagementApi.Services.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorService, AuthorService>();

            return services;
        }

        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }

        public static IServiceCollection AddRedisCacheService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("Redis");
                options.InstanceName = "LibraryCache_";
            });
            services.AddScoped<RedisCacheService>();
            return services;
        }

        public static IServiceCollection AddExceptionHandler(this IServiceCollection services)
        {
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();
            
            return services;
        }
    }
}
