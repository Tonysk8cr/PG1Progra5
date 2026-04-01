using Microsoft.Extensions.Logging;
using EstudiantesAppWeb.Estudiante;
using EstudiantesApp.Services;

namespace EstudiantesApp
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

            // Singleton: una sola instancia compartida en toda la app
            // Necesario para que el evento OnChange y el estado funcionen correctamente
            builder.Services.AddSingleton<EstudianteService>();

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
