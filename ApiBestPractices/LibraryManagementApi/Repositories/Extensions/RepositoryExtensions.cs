using LibraryManagementApi.Repositories.Authors;
using LibraryManagementApi.Repositories.Books;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementApi.Repositories.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            return services;
        }
    }
}
