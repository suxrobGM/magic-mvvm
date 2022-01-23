namespace MagicMvvm.Navigation;

internal class NavigationRegistry : INavigationRegistry
{
    public static readonly NavigationRegistry Instance = new();

    private readonly IDictionary<string, Type> _pages;

    private NavigationRegistry()
    {
        _pages = new Dictionary<string, Type>();
    }

    public INavigationRegistry RegisterPage<T>(string pageName) where T : Page
    {
        if (string.IsNullOrEmpty(pageName))
            throw new ArgumentNullException(nameof(pageName));

        if (_pages.ContainsKey(pageName))
            throw new InvalidOperationException($"Page is already registered with name {pageName}");

        _pages.Add(pageName, typeof(T));
        Routing.RegisterRoute(pageName, typeof(T));
        return this;
    }

    public Type GetPage(string pageName)
    {
        if (!_pages.ContainsKey(pageName))
            throw new InvalidOperationException($"Page with name {pageName} is not registered");

        return _pages[pageName];
    }
}
