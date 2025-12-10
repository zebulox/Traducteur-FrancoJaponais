using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Plugin.Maui.OCR;
using Traducteur_FrancoJaponais.Model;
using Traducteur_FrancoJaponais.Services;
using Traducteur_FrancoJaponais.Services.DataBase.Interface;
using Traducteur_FrancoJaponais.Services.Permissions.Interface;

namespace Traducteur_FrancoJaponais
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
                }).UseOcr(); 

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddSingleton<IDataBaseService>(new DataBaseService());
            builder.Services.AddSingleton<IDataManager<HiromiCourse>>(new DataManagerService<HiromiCourse>(builder.Services.BuildServiceProvider().GetService<IDataBaseService>()));
            builder.Services.AddSingleton<IDataManager<HiromiPhrase>>(new DataManagerService<HiromiPhrase>(builder.Services.BuildServiceProvider().GetService<IDataBaseService>()));
            builder.Services.AddSingleton<IPermissionManager>(new PermissionManager());
            /*Faire la DI ici ex:*/
            /*
            builder.Services.AddTransient<ILogger>();
            builder.Services.AddSingleton<ILoggerFactory>();
            ...
            */
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
