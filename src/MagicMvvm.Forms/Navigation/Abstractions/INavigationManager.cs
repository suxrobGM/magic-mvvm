namespace MagicMvvm.Navigation;

/// <summary>
/// Navigation manager for handling navigations
/// </summary>
/// <remarks>
/// Register type as a singleton if you are using IoC container.
/// </remarks>
public interface INavigationManager
{
    /// <summary>
    /// Registers page for the navigation.
    /// </summary>
    /// <param name="pageName">The unique page name</param>
    /// <returns>Instance of <see cref="INavigationManager"/>, for easily adding several pages</returns>
    /// <typeparam name="T">Type of the page</typeparam>
    /// <exception cref="ArgumentNullException">
    ///     Throws exception if <paramref name="pageName"/> is null or empty
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     Throws exception if page with name <paramref name="pageName"/> is already registered.
    /// </exception>

    INavigationManager RegisterPage<T>(string pageName) where T : Page;

    /// <summary>
    /// Navigates to the specified page.
    /// </summary>
    /// <param name="pageName">The name of the page that registered for navigation manager.</param>
    /// <param name="navigationCallback">The navigation callback that will be executed after the navigation is completed.</param>
    /// <param name="parameters">Navigation parameters to pass arguments between views.</param>
    /// <returns>The <see cref="INavigationResult"/>.</returns>
    /// <exception cref="InvalidOperationException">
    ///     Throws exception if <paramref name="pageName"/> was not registered in navigation manager
    /// </exception>
    Task<INavigationResult> NavigateToAsync(string pageName, Action navigationCallback,
        IParameters parameters);

    /// <summary>
    /// Performs backward navigation.
    /// </summary>
    /// <param name="navigationCallback">The navigation callback that will be executed after the navigation is completed.</param>
    /// <param name="parameters">Navigation parameters to pass arguments between views.</param>
    /// <returns>The <see cref="INavigationResult"/>.</returns>
    Task<INavigationResult> GoBackAsync(Action navigationCallback,
        IParameters parameters);
}