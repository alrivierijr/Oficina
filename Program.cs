using Oficina.Components;
using Serilog;
using Microsoft.EntityFrameworkCore;
using Oficina.Data;

namespace Oficina
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Directory.CreateDirectory("Logs");
            
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(
                "Logs/oficina-.log",
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: 7,
                restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information
            )
            .CreateLogger();

            builder.Host.UseSerilog();

            // J13112025 - Add DbContext com PostgreSQL
            builder.Services.AddDbContext<AppDbContext>(Options =>
            Options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
