using LibraryManagementSystem.Data.Data;
using LibraryManagementSystem.Models.AppUsers;
using LibraryManagementSystem.Services.AppRoles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Data.DbInitializer
{
    public class DbInitializer(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager) : IDbInitializer
    {
        public void Initialize()
        {
            try
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
            }
            catch (Exception ex){ }

            if (!roleManager.RoleExistsAsync(AppRole.Member).GetAwaiter().GetResult())
            {
                string[] roles = { AppRole.Member, AppRole.Admin, AppRole.Librarian };

                foreach (var role in roles)
                {
                    if (!roleManager.RoleExistsAsync(role).GetAwaiter().GetResult())
                    {
                        roleManager.CreateAsync(new IdentityRole(role)).GetAwaiter().GetResult();
                    }
                }
                var adminEmail = "admin@library.com";
                userManager.CreateAsync(new AppUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    Name = "Ali Armagan Uygun",
                    PhoneNumber = "1234567890",
                    Role = AppRole.Admin

                }, "Admin123*").GetAwaiter().GetResult();

                AppUser user = context.AppUsers.FirstOrDefault(u => u.Email == adminEmail)!;

                userManager.AddToRoleAsync(user, AppRole.Admin).GetAwaiter().GetResult();
            }
        }
    }
}