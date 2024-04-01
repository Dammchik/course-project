using BarbershopWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BarbershopWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Добавление контекста базы данных как сервиса
            builder.Services.AddDbContext<BarbershopContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("BarbershopDatabase")));

            // Добавление контроллеров и представлений
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Конфигурация пайплайна HTTP-запросов.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
