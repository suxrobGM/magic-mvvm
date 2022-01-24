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
    protected readonly INavigationRegistry _navigationRegistry;

    public NavigationManager(IAppProvider appProvider, 
        INavigationRegistry navigationRegistry)
    {
        _appProvider = appProvider;
        _navigationRegistry = navigationRegistry;
    }

    public virtual async Task<INavigationResult> NavigateToAsync(string pageName, Action navigationCallback,
        IParameters parameters)
    {
        try
        {
            var targetPageType = _navigationRegistry.GetPage(pageName);
            var currentPage = _appProvider.MainPage;
            var targetPage = _appProvider.ServiceProvider.GetRequiredService(targetPageType) as Page;
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