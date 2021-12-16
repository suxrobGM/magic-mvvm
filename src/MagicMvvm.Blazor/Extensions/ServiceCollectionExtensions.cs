using MagicMvvm.Parameters;
using Microsoft.Extensions.DependencyInjection;

namespace MagicMvvm;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds MVVM support.
    /// </summary>
    /// <param name="services">Instance of <see cref="IServiceCollection"/>.</param>
    /// <returns>The <see cref="IServiceCollection"/></returns>
    public static IServiceCollection AddMvvmBlazor(this IServiceCollection services)
    {
        services.AddSingleton<IParameterResolver, ParameterResolver>();
        services.AddSingleton<IParameterCache, ParameterCache>();
        services.AddSingleton<IParameterSetter, ParameterSetter>();
            
        var viewModelType = typeof(ViewModelBase);
        var definedTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(i => i.DefinedTypes);

        foreach (var type in definedTypes)
        {
            if (viewModelType.IsAssignableFrom(type) &&
                type.IsClass && !type.IsAbstract)
            {
                services.AddScoped(type);
            }
        }
        return services;
    }
}