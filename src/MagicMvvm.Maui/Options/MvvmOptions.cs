using MagicMvvm.Navigation;

namespace MagicMvvm.Options;

public class MvvmOptions
{
    public MvvmOptions()
    {
        Navigation = NavigationRegistry.Instance;
    }

    /// <summary>
    /// Automatically wires viewmodels to views
    /// </summary>
    public bool AutoWireViewModels { get; set; } = true;

    /// <summary>
    /// Register pages for navigation
    /// </summary>
    public INavigationRegistry Navigation { get; }
}
