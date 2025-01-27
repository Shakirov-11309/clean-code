
using MarkDown.DataBase;
using MarkDown.DataBase.repository;
using MarkDown.Infastructure;
using Microsoft.EntityFrameworkCore;
using WebAPI.Middleware;
using WebAPI.Services;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;


            builder.Services.Configure<JwtOption>(configuration.GetSection(nameof(JwtOption)));
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<MyDbContext>(
                options =>
                {
                    options.UseNpgsql(configuration.GetConnectionString(nameof(MyDbContext)));
                });
            Console.WriteLine(configuration.GetConnectionString(nameof(MyDbContext)));
            builder.Services.AddScoped<JwtProvider>();
            builder.Services.AddScoped<JwtOption>();
            builder.Services.AddScoped<PasswordHasher>();
            builder.Services.AddScoped<UsersRepository>();
            builder.Services.AddScoped<UsersService>();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseMiddleware<AuthCheckMiddleware>();

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();
            app.UseStaticFiles();
            app.MapDefaultControllerRoute();

            app.Run();
        }
    }
}
