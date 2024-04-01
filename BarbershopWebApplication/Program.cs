using BarbershopWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BarbershopWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ���������� ��������� ���� ������ ��� �������
            builder.Services.AddDbContext<BarbershopContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("BarbershopDatabase")));

            // ���������� ������������ � �������������
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // ������������ ��������� HTTP-��������.
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
