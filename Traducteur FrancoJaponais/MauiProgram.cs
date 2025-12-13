using DataModels.Model;
using Microsoft.Extensions.Logging;
using Plugin.Maui.OCR;
using Traducteur_FrancoJaponais.Services.DataBase;
using Traducteur_FrancoJaponais.Services.DataBase.Interface;
using Traducteur_FrancoJaponais.Services.Permission;
using Traducteur_FrancoJaponais.Services.Permission.Interface;

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
            builder.Services.AddSingleton<IDataManager<Article_Db>>(new DataManagerService<Article_Db>(builder.Services.BuildServiceProvider().GetService<IDataBaseService>()));
            builder.Services.AddSingleton<IDataManager<Sens_DB>>(new DataManagerService<Sens_DB>(builder.Services.BuildServiceProvider().GetService<IDataBaseService>()));
            builder.Services.AddSingleton<IDataManager<Segment_DB>>(new DataManagerService<Segment_DB>(builder.Services.BuildServiceProvider().GetService<IDataBaseService>()));
            builder.Services.AddSingleton<IPermissionManager>(new PermissionManager());
            builder.Services.AddSingleton<IDataBaseInitializer>(new DataBaseInitializer(builder.Services.BuildServiceProvider().GetService<IDataBaseService>().Getdatabase()));
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
