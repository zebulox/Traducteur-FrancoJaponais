using DataModels.Model;
using DataModels.Model.Dictionary;
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
            builder.Services.AddSingleton<IDataManager<Word>>(new DataManagerService<Word>(builder.Services.BuildServiceProvider().GetService<IDataBaseService>()));
            builder.Services.AddSingleton<IDataManager<FrenchWord>>(new DataManagerService<FrenchWord>(builder.Services.BuildServiceProvider().GetService<IDataBaseService>()));
            builder.Services.AddSingleton<IDataManager<JapaneseWord>>(new DataManagerService<JapaneseWord>(builder.Services.BuildServiceProvider().GetService<IDataBaseService>()));
            builder.Services.AddSingleton<IDataManager<Tag>>(new DataManagerService<Tag>(builder.Services.BuildServiceProvider().GetService<IDataBaseService>()));
            builder.Services.AddSingleton<IDataManager<WordFrench>>(new DataManagerService<WordFrench>(builder.Services.BuildServiceProvider().GetService<IDataBaseService>()));
            builder.Services.AddSingleton<IDataManager<WordJapanese>>(new DataManagerService<WordJapanese>(builder.Services.BuildServiceProvider().GetService<IDataBaseService>()));
            builder.Services.AddSingleton<IDataManager<WordTag>>(new DataManagerService<WordTag>(builder.Services.BuildServiceProvider().GetService<IDataBaseService>()));

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
