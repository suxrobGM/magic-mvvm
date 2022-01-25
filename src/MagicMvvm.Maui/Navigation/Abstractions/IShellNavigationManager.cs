namespace MagicMvvm.Navigation;

/// <summary>
/// Navigation manager for handling navigations between pages in shell application.
/// </summary>
/// <remarks>
/// Register type as a singleton if you are using IoC container.
/// </remarks>
public interface IShellNavigationManager : INavigationManager
{
    /// <summary>
    /// Registers shell.
    /// </summary>
    /// <param name="instance">Instance of the shell</param>
    /// <typeparam name="T">Type of the shell</typeparam>
    /// <exception cref="ArgumentNullException">
    ///     Throws exception if <paramref name="instance"/> is null.
    /// </exception>
    /// <returns>Instance of <see cref="INavigationManager"/>, for easily adding several shells.</returns>
    //internal INavigationManager RegisterShell<T>(T instance) where T : Shell;
}