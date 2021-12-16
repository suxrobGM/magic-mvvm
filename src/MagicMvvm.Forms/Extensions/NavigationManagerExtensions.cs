namespace MagicMvvm.Navigation;

/// <summary>
/// Extension methods for the <see cref="INavigationManager"/>
/// </summary>
public static class NavigationManagerExtensions
{
    /// <summary>
    /// Register page for the navigation.
    /// </summary>
    /// <param name="navigationManager">Instance of <see cref="INavigationManager"/>.</param>
    /// <typeparam name="TView">Type of the view</typeparam>
    /// <returns>The <see cref="INavigationManager"/>, for adding several views easily</returns>
    public static INavigationManager RegisterPage<TView>(this INavigationManager navigationManager)
        where TView : Page
    {
        var pageName = typeof(TView).Name;
        navigationManager.RegisterPage<TView>(pageName);
        return navigationManager;
    }

    /// <summary>
    /// Navigates to the specified page.
    /// </summary>
    /// <param name="navigationManager">Instance of <see cref="INavigationManager"/>.</param>
    /// <param name="pageName">The name of the page that registered for navigation manager.</param>
    /// <returns>The <see cref="INavigationResult"/>.</returns>
    /// <exception cref="InvalidOperationException">
    ///     Throws exception if <paramref name="pageName"/> is not registered in navigation manager.
    /// </exception>
    public static Task<INavigationResult> NavigateToAsync(this INavigationManager navigationManager, string pageName)
    {
        return navigationManager.NavigateToAsync(pageName, null, null);
    }

    /// <summary>
    /// Navigates to the specified page.
    /// </summary>
    /// <param name="navigationManager">Instance of <see cref="INavigationManager"/>.</param>
    /// <param name="pageName">The name of the page that registered for navigation manager.</param>
    /// <param name="navigationParameters">Navigation parameters to pass arguments between views.</param>
    /// <returns>The <see cref="INavigationResult"/>.</returns>
    /// <exception cref="InvalidOperationException">
    ///     Throws exception if <paramref name="pageName"/> is not registered in navigation manager.
    /// </exception>
    public static Task<INavigationResult> NavigateToAsync(this INavigationManager navigationManager,
        string pageName, IParameters navigationParameters)
    {
        return navigationManager.NavigateToAsync(pageName, null, navigationParameters);
    }

    /// <summary>
    /// Navigates to the specified page.
    /// </summary>
    /// <param name="navigationManager">Instance of <see cref="INavigationManager"/>.</param>
    /// <param name="pageName">The name of the page that registered for navigation manager.</param>
    /// <param name="navigationCallback">The navigation callback that will be executed after the navigation is completed.</param>
    /// <returns>The <see cref="INavigationResult"/>.</returns>
    /// <exception cref="InvalidOperationException">
    ///     Throws exception if <paramref name="pageName"/> is not registered in navigation manager.
    /// </exception>
    public static Task<INavigationResult> NavigateToAsync(this INavigationManager navigationManager,
        string pageName, Action navigationCallback)
    {
        return navigationManager.NavigateToAsync(pageName, navigationCallback, null);
    }

    /// <summary>
    /// Performs backward navigation.
    /// </summary>
    /// <param name="navigationManager">Instance of <see cref="INavigationManager"/>.</param>
    /// <returns>The <see cref="INavigationResult"/>.</returns>
    public static Task<INavigationResult> GoBackAsync(this INavigationManager navigationManager)
    {
        return navigationManager.GoBackAsync(null, null);
    }

    /// <summary>
    /// Performs backward navigation.
    /// </summary>
    /// <param name="navigationManager">Instance of <see cref="INavigationManager"/>.</param>
    /// <param name="navigationCallback">The navigation callback that will be executed after the navigation is completed.</param>
    /// <returns>The <see cref="INavigationResult"/>.</returns>
    public static Task<INavigationResult> GoBackAsync(this INavigationManager navigationManager,
        Action navigationCallback)
    {
        return navigationManager.GoBackAsync(navigationCallback, null);
    }

    /// <summary>
    /// Performs backward navigation.
    /// </summary>
    /// <param name="navigationManager">Instance of <see cref="INavigationManager"/>.</param>
    /// <param name="navigationParameters">Navigation parameters to pass arguments between views.</param>
    /// <returns>The <see cref="INavigationResult"/>.</returns>
    public static Task<INavigationResult> GoBackAsync(this INavigationManager navigationManager,
        IParameters navigationParameters)
    {
        return navigationManager.GoBackAsync(null, navigationParameters);
    }
}