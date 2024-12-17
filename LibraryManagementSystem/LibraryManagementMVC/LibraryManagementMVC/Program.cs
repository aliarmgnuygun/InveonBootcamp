using LibraryManagementSystem.Data.DbInitializer;
using LibraryManagementSystem.Services.ExceptionHandlers;
using LibraryManagementSystem.Services.Extensions;

namespace LibraryManagementMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddServicesAndConfigs(builder.Configuration).AddRepositories();
            builder.Services.AddRazorPages();
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddServices().AddRepositories();
            builder.Services.AddScoped<IDbInitializer, DbInitializer>();
            builder.Services.AddIdentityServices();

            builder.Services.AddExceptionHandler<NotFoundExceptionHandler>().AddExceptionHandler<GlobalExceptionHandler>();

            var app = builder.Build();
            app.AddSeedData();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.MapRazorPages();
            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{area=Member}/{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
