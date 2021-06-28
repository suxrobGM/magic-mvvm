using System;

namespace MagicMvvm.Navigation
{
    /// <summary>
    /// Interface of navigation manager.
    /// </summary>
    /// <remarks>
    /// Register type as a singleton inside container.
    /// </remarks>
    public interface INavigationManager
    {
        /// <summary>
        /// Register region name and region view's instance inside registrar. Associate a view with a region, using a concrete instance of the view.
        /// </summary>
        /// <param name="regionName">The name of the region to associate the view with.</param>
        /// <param name="viewInstance">The instance of the view which associated with region name.</param>
        /// <exception cref="ArgumentNullException">Throws exception if <paramref name="regionName"/> or <paramref name="viewInstance"/> is null or empty</exception>
        /// <returns>The <see cref="INavigationManager"/>, for adding several views easily</returns>
        INavigationManager RegisterRegionWithView(string regionName, object viewInstance);

        /// <summary>
        /// Register view name and view source inside registrar. Configures specified view for navigation.
        /// </summary>
        /// <param name="viewName">The unique view name</param>
        /// <typeparam name="TView">Type of the view</typeparam>
        /// <exception cref="ArgumentNullException">Throws exception if <paramref name="viewName"/> is null or empty</exception>
        /// <exception cref="InvalidOperationException">Throws exception if application does not have any resource files or could not locate to resource files</exception>
        /// <returns>The <see cref="INavigationManager"/>, for adding several views easily</returns>
        INavigationManager RegisterView<TView>(string viewName);

        /// <summary>
        /// Navigates the specified view to the region.
        /// </summary>
        /// <param name="regionName">The name of the region to call Navigate on.</param>
        /// <param name="viewName">The name of the view that registered for navigation inside manager.</param>
        /// <param name="navigationCallback">The navigation callback that will be executed after the navigation is completed.</param>
        /// <param name="navigationParameters">Navigation parameters to pass arguments between views.</param>
        /// <exception cref="InvalidOperationException">Throws exception if <paramref name="viewName"/> or <paramref name="regionName"/> was not registered in internal registrar</exception>
        void RequestNavigate(string regionName, string viewName, Action navigationCallback, INavigationParameters navigationParameters);
    }
}