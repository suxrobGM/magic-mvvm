namespace MagicMvvm.AppModel;

/// <summary>
/// Provides Application components.
/// </summary>
internal class AppProvider : IAppProvider
{
    public Page MainPage => Application.Current?.MainPage;
    public Shell CurrentShell => Shell.Current;
}