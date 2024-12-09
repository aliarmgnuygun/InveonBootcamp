using LibraryManagementApi.Repositories.Extensions;
using LibraryManagementApi.Services.Extensions;

namespace LibraryManagementApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
         
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddRepositories(builder.Configuration).AddServices().AddAutoMapper().AddRedisCacheService(builder.Configuration);
            builder.Services.AddExceptionHandler();

            var app = builder.Build();

            app.UseExceptionHandler();
            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
           
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
