using Microsoft.Extensions.Logging;
using CaddyMac.Data;

namespace CaddyMac
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // SQLite Database Path
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "caddymac.db3");

            // Register Database Service
            builder.Services.AddSingleton<DatabaseService>(
                s => new DatabaseService(dbPath));

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
