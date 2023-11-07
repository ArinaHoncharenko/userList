using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Налаштування сервісів для додатка
        services.AddControllersWithViews();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            // Використовувати сторінку помилок під час розробки
            app.UseDeveloperExceptionPage();
        }
        else
        {
            // Використовувати обробник помилок у виробничому середовищі
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        // Використання статичних файлів
        app.UseStaticFiles();

        // Налаштування маршрутизації для контролерів та дій
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=User}/{action=Index}/{id?}");
        });
    }
}
