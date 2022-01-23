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
    /// Uses shell navigation instead usual page navigation
    /// </summary>
    public bool UseShellNavigation { get; set; }

    /// <summary>
    /// Register pages for navigation
    /// </summary>
    public INavigationRegistry Navigation { get; }
}
