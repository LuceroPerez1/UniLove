using Microsoft.EntityFrameworkCore;
using UniLove.Models;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Agregar soporte para sesiones
        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30); // Tiempo de expiración de la sesión
            options.Cookie.IsEssential = true; // Hacer la cookie esencial
        });

        // Configuración del DbContext
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddRazorPages();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        // Usar sesiones
        app.UseSession();

        app.UseRouting();
        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}

