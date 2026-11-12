using DadJoke.ViewModels;
using DadJoke.Views;
using Microsoft.Extensions.Logging;
using DadJoke.Services;
using DadJoke.Interfaces;

namespace DadJoke
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<IConfigurationServices, ConfigurationService>();
            builder.Services.AddSingleton<IDadJokesHttpApiServices, DadJokesHttpApiServices>();
            builder.Services.AddSingleton<IPopUp, MauiPopupService>();
            //builder.Services.AddSingleton<I>

            builder.Services.AddTransient<JokesViewModel>();
            builder.Services.AddTransient<JokesView>();

            return builder.Build();
        }
    }
}
