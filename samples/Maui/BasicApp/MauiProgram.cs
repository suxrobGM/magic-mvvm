using BasicApp.Views;
using MagicMvvm;

namespace BasicApp;

public static class MauiProgram
{
    private static IServiceProvider serviceProvider;

    public static T GetService<T>() => serviceProvider.GetService<T>();

    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        // Adds MagicMvvm
        builder.Services.AddMvvmMaui(o =>
        {
            o.Navigation.RegisterPage<PageA>(nameof(PageA));
            o.Navigation.RegisterPage<PageB>(nameof(PageB));
        });
         

        var mauiApp = builder.Build();
        serviceProvider = mauiApp.Services;
        return mauiApp;
    }
}