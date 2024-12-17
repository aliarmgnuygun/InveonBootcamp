using LibraryManagementSystem.Data.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagementSystem.Services.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            // Identity yapılandırması
            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();

            // Cookie ayarları
            services.ConfigureApplicationCookie(opt =>
            {
                var cookieBuilder = new CookieBuilder
                {
                    Name = "InveonAppCookie"
                };

                opt.LoginPath = $"/Identity/Account/Login";
                opt.LogoutPath = $"/Identity/Account/Logout";
                opt.AccessDeniedPath = $"/Identity/Account/AccessDenied";
                opt.Cookie = cookieBuilder;
                opt.ExpireTimeSpan = TimeSpan.FromDays(60);
                opt.SlidingExpiration = true;
            });


            return services;
        }
    }
}