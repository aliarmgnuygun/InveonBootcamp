using LibraryManagementSystem.Data.Data.Configurations;
using LibraryManagementSystem.Models.AppUsers;
using LibraryManagementSystem.Models.Books;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace LibraryManagementSystem.Data.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly); // This line is added to apply configurations from all classes that implement IEntityTypeConfiguration

            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new BookConfiguration());
            builder.ApplyConfiguration(new AppUserConfiguration());
        }
    }
}