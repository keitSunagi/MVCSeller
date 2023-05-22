using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebSalesMVC.Data;
namespace WebSalesMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serverVersion = new MySqlServerVersion(new Version(8,0,33));

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<WebSalesMVCContext>(options =>
                options.UseMySql(builder.Configuration.GetConnectionString("WebSalesMVCContext"), serverVersion,builder => builder.MigrationsAssembly("WebSalesMVC")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<SeedingService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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