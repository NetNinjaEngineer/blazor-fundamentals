using Microsoft.EntityFrameworkCore;
using Tangy_Business.Repository;
using Tangy_Business.Repository.IRepository;
using Tangy_DataAccess.Data;
using TangyWeb_Server.Helpers;

namespace TangyWeb_Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddScoped<ToastService>();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<Components.App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
