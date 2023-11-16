using BookDesktop.Data;
using BookDesktop.Pages;
using BookDesktop.Service;
using Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookDesktop
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddScoped<AuthService>();
            builder.Services.AddDbContext<AppDbContext>((options) =>
            {
                options.UseSqlite($"Data Source={@"C:\Projects\CourseWork\MyDatabase.db"}");
            });
            builder.Services.AddSingleton<BinService>();
            var app = builder.Build();

            var dbcontext = app.Services.GetRequiredService<AppDbContext>();
            dbcontext.Database.EnsureCreated();
            
            return app;
        }
    }
}
