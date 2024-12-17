using LibraryManagementSystem.Data.DbInitializer;
using LibraryManagementSystem.Data.Repositories;
using LibraryManagementSystem.Services.AppUsers;
using LibraryManagementSystem.Services.Books;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LibraryManagementSystem.Services.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IEmailSender, EmailSender>();
            //services.AddAutoMapper(typeof(BookService).Assembly);
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
        public static void AddSeedData(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
                dbInitializer.Initialize();
            }
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}