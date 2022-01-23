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
    /// <returns>The <see cref="IMvvmBuilder"/></returns>
    public static IMvvmBuilder AddMvvmMaui(this IServiceCollection services)
    {
        return services.AddMvvmMaui(new MvvmOptions());
    }

    /// <summary>
    /// Adds MVVM support.
    /// </summary>
    /// <param name="services">Instance of <see cref="IServiceCollection"/>.</param>
    /// <returns>The <see cref="IMvvmBuilder"/></returns>
    public static IMvvmBuilder AddMvvmMaui(this IServiceCollection services, Action<MvvmOptions> configure)
    {
        var options = new MvvmOptions();
        configure.Invoke(options);
        return services.AddMvvmMaui(options);
    }

    /// <summary>
    /// Adds MVVM support.
    /// </summary>
    /// <param name="services">Instance of <see cref="IServiceCollection"/>.</param>
    /// <returns>The <see cref="IMvvmBuilder"/></returns>
    public static IMvvmBuilder AddMvvmMaui(this IServiceCollection services, MvvmOptions options)
    {
        services.AddScoped<IKeyboardMapper, KeyboardMapper>();
        services.AddScoped<IActionSheetButton, ActionSheetButton>();
        services.AddSingleton<IMvvmBuilder, MvvmBuilder>();
        services.AddSingleton<IAppProvider, AppProvider>();
        services.AddSingleton<INavigationManager, NavigationManager>();
        services.AddSingleton<IShellNavigationManager, ShellNavigationManager>();
        services.AddSingleton<IDialogManager, DialogManager>();
        services.AddSingleton<IPopupDialog, PopupDialog>();
        services.AddSingleton(options);
        RegisterTypes<ViewModelBase>(services); // register view models
         

        var serviceProvider = services.BuildServiceProvider();

        // register views
        if (options.AutoWireViewModels)
        {
            RegisterTypes<VisualElement>(services, WireViewModel);
        }
        else
        {
            RegisterTypes<VisualElement>(services);
        }

        return serviceProvider.GetRequiredService<IMvvmBuilder>();
    }

    private static void RegisterTypes<T>(IServiceCollection services, 
        Func<IServiceProvider, Type, object> factory = null)
    {
        var dataType = typeof(T);
        var definedTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(i => i.DefinedTypes)
            .Where(i => i.IsClass && i.IsAbstract);

        foreach (var type in definedTypes)
        {
            var attr = type.GetCustomAttribute<ServiceLifetimeAttribute>();
            if (dataType.IsAssignableFrom(type))
            {
                if (attr == null)
                {
                    services.AddScoped(type, i => factory?.Invoke(i, type));
                    continue;
                }

                switch (attr.ServiceLifetime)
                {
                    case ServiceLifetime.Scoped:
                        services.AddScoped(type, i => factory?.Invoke(i, type));
                        break;
                    case ServiceLifetime.Transient:
                        services.AddTransient(type, i => factory?.Invoke(i, type));
                        break;
                    case ServiceLifetime.Singleton:
                        services.AddSingleton(type, i => factory?.Invoke(i, type));
                        break;
                    default:
                        services.AddScoped(type, i => factory?.Invoke(i, type));
                        break;
                }
            }
        }
    }

    //private static void WireViewModels(IServiceProvider serviceProvider)
    //{
    //    var visualElementType = typeof(VisualElement);
    //    var definedTypes = AppDomain.CurrentDomain.GetAssemblies()
    //        .SelectMany(i => i.DefinedTypes)
    //        .Where(i => i.IsClass && !i.IsAbstract);

    //    foreach (var type in definedTypes)
    //    {
    //        if (type.IsAssignableFrom(visualElementType))
    //        {
    //            var viewModelType = definedTypes.FirstOrDefault(i =>
    //                i.IsAssignableFrom(typeof(ViewModelBase)) &&
    //                i.Name.Contains(type.Name) && 
    //                i.Name.EndsWith("ViewModel"));

    //            if (viewModelType == null)
    //                continue;

    //            var view = serviceProvider.GetService(type) as VisualElement;
    //            var viewModel = serviceProvider.GetService(viewModelType);
    //            view.BindingContext = viewModel;
    //        }
    //    }
    //}

    private static object WireViewModel(IServiceProvider serviceProvider, Type viewType)
    {
        var viewModelType = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(i => i.DefinedTypes)
            .FirstOrDefault(i => i.IsClass && !i.IsAbstract &&
                    i.IsAssignableFrom(typeof(ViewModelBase)) &&
                    i.Name.Contains(viewType.Name) &&
                    i.Name.EndsWith("ViewModel"));

        var viewModel = serviceProvider.GetService(viewModelType);
        var ctorParams = GetCtorParameters(serviceProvider, viewType);
        var view = Activator.CreateInstance(viewType, ctorParams) as VisualElement;
        if (viewModel != null)
        {
            view.BindingContext = viewModel;
        }

        return view;
    }

    private static object[] GetCtorParameters(IServiceProvider serviceProvider, Type type)
    {
        var ctorParams = new List<object>();
        var parameters = type.GetConstructors().FirstOrDefault(i => i.IsPublic)?.GetParameters();

        if (parameters is null)
        {
            return null;
        }

        foreach (var parameter in parameters)
        {
            ctorParams.Add(serviceProvider.GetRequiredService(parameter.ParameterType));
        }
        return ctorParams.ToArray();
    }
}