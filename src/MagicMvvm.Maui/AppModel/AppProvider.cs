namespace MagicMvvm.AppModel;

/// <summary>
/// Provides Application components.
/// </summary>
public class AppProvider : IAppProvider
{
    public AppProvider(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
    }

    public Page MainPage => Application.Current?.MainPage;
    public Shell CurrentShell => Shell.Current;

    public IServiceProvider ServiceProvider { get; }
}