using MagicMvvm.AppModel;

namespace MagicMvvm.Navigation;

/// <summary>
/// Implements <see cref="INavigationManager"/> to handle navigation between pages.
/// </summary>
/// <remarks>
/// Register type as a singleton if you are using IoC container.
/// </remarks>
public class NavigationManager : INavigationManager
{
    protected readonly IAppProvider _appProvider;
    protected readonly IDictionary<string, Type> _pages;

    public NavigationManager()
    {
        _appProvider = new AppProvider();
        _pages = new Dictionary<string, Type>();
    }

    public virtual INavigationManager RegisterPage<T>(string pageName) where T : Page
    {
        if (string.IsNullOrEmpty(pageName))
            throw new ArgumentNullException(nameof(pageName));

        if (_pages.ContainsKey(pageName))
            throw new InvalidOperationException($"Page is already registered with name {pageName}");

        _pages.Add(pageName, typeof(T));
        return this;
    }

    public virtual async Task<INavigationResult> NavigateToAsync(string pageName, Action navigationCallback,
        IParameters parameters)
    {
        if (!_pages.ContainsKey(pageName))
            throw new InvalidOperationException($"Page with name {pageName} is not registered");

        try
        {
            var currentPage = _appProvider.MainPage;
            var targetPage = Activator.CreateInstance(_pages[pageName]) as Page;
            (currentPage?.BindingContext as INavigationAware)?.OnNavigatedFrom(parameters);

            await currentPage.Navigation.PushAsync(targetPage);

            (targetPage?.BindingContext as INavigationAware)?.OnNavigatedTo(parameters);
            navigationCallback?.Invoke();

            return new NavigationResult
            {
                Success = true,
                Exception = null
            };
        }
        catch (Exception e)
        {
            return new NavigationResult
            {
                Success = false,
                Exception = e
            };
        }
    }

    public virtual async Task<INavigationResult> GoBackAsync(Action navigationCallback,
        IParameters parameters)
    {
        try
        {
            var currentPage = _appProvider.MainPage;
            (currentPage?.BindingContext as INavigationAware)?.OnNavigatedFrom(parameters);

            var targetPage = await currentPage.Navigation.PopAsync(false);

            (targetPage?.BindingContext as INavigationAware)?.OnNavigatedTo(parameters);
            navigationCallback?.Invoke();

            return new NavigationResult
            {
                Success = true,
                Exception = null
            };
        }
        catch (Exception e)
        {
            return new NavigationResult
            {
                Success = false,
                Exception = e
            };
        }
    }
}