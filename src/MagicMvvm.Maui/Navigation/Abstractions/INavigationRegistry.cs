namespace MagicMvvm.Navigation;

public interface INavigationRegistry
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
    INavigationRegistry RegisterPage<T>(string pageName) where T : Page;

    internal Type GetPage(string pageName);
}
