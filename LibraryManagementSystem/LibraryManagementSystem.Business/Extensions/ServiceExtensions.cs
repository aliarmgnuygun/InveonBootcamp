using LibraryManagementSystem.Business.Books;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagementSystem.Business.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddAutoMapper(typeof(BookService).Assembly);
            return services;
        }
    }
}
