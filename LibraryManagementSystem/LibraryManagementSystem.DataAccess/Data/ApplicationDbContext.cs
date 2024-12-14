using LibraryManagementSystem.DataAccess.Data.Configurations;
using LibraryManagementSystem.Models.Books;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly); // This line is added to apply configurations from all classes that implement IEntityTypeConfiguration

            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new BookConfiguration());
        }
    }
}