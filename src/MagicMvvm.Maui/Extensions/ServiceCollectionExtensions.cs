using System.Reflection;
using MagicMvvm.AppModel;
using MagicMvvm.Attributes;
using MagicMvvm.Dialogs;
using MagicMvvm.Navigation;
using MagicMvvm.Options;

namespace MagicMvvm;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds MVVM support.
    /// </summary>
    /// <param name="services">Instance of <see cref="IServiceCollection"/>.</param>
    /// <returns>The <see cref="IServiceCollection"/></returns>
    public static IServiceCollection AddMvvmMaui(this IServiceCollection services, Action<MvvmMauiOptions> configure)
    {
        var options = new MvvmMauiOptions();
        configure.Invoke(options);
        return services.AddMvvmMaui(options);
    }

    /// <summary>
    /// Adds MVVM support.
    /// </summary>
    /// <param name="services">Instance of <see cref="IServiceCollection"/>.</param>
    /// <returns>The <see cref="IServiceCollection"/></returns>
    public static IServiceCollection AddMvvmMaui(this IServiceCollection services, MvvmMauiOptions options)
    {
        services.AddScoped<IAppProvider, AppProvider>();
        services.AddScoped<IKeyboardMapper, KeyboardMapper>();
        services.AddScoped<IActionSheetButton, ActionSheetButton>();
        services.AddSingleton<INavigationManager, NavigationManager>();
        services.AddSingleton<IShellNavigationManager, ShellNavigationManager>();
        services.AddSingleton<IDialogManager, DialogManager>();
        services.AddSingleton<IPopupDialog, PopupDialog>();

        RegisterTypes<ViewModelBase>(services); // register view models
        RegisterTypes<VisualElement>(services); // register views

        if (options.AutoWireViewModels)
        {
            WireViewModels(services.BuildServiceProvider());
        }

        return services;
    }

    private static void RegisterTypes<T>(IServiceCollection services)
    {
        var dataType = typeof(T);
        var definedTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(i => i.DefinedTypes);

        foreach (var type in definedTypes)
        {
            var attr = type.GetCustomAttribute<ServiceLifetimeAttribute>();
            if (dataType.IsAssignableFrom(type) &&
                type.IsClass && !type.IsAbstract)
            {
                if (attr == null)
                {
                    services.AddScoped(type);
                    continue;
                }

                switch (attr.ServiceLifetime)
                {
                    case ServiceLifetime.Scoped:
                        services.AddScoped(type);
                        break;
                    case ServiceLifetime.Transient:
                        services.AddTransient(type);
                        break;
                    case ServiceLifetime.Singleton:
                        services.AddSingleton(type);
                        break;
                    default:
                        services.AddScoped(type);
                        break;
                }
            }
        }
    }

    private static void WireViewModels(IServiceProvider serviceProvider)
    {
        var visualElementType = typeof(VisualElement);
        var definedTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(i => i.DefinedTypes);

        foreach (var type in definedTypes)
        {
            if (type.IsClass && !type.IsAbstract &&
                type.IsAssignableFrom(visualElementType))
            {
                var viewModelType = definedTypes.FirstOrDefault(i =>
                    i.IsClass && !i.IsAbstract &&
                    i.IsAssignableFrom(typeof(ViewModelBase)) &&
                    i.Name.Contains(type.Name) && 
                    i.Name.EndsWith("ViewModel"));

                if (viewModelType == null)
                    continue;

                var view = serviceProvider.GetService(type) as VisualElement;
                var viewModel = serviceProvider.GetService(viewModelType);
                view.BindingContext = viewModel;
            }
        }
    }
}