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
        /// <returns>The <see cref="INavigationManager"/>, for adding several views easily</returns>
        INavigationManager RegisterRegionWithView(string regionName, object viewInstance);

        /// <summary>
        /// Register view name and view source inside registrar. Configures specified view for navigation.
        /// </summary>
        /// <param name="viewName">The view name</param>
        /// <param name="viewSource">The URI of specified view</param>
        /// <returns>The <see cref="INavigationManager"/>, for adding several views easily</returns>
        INavigationManager RegisterView(string viewName, Uri viewSource);

        /// <summary>
        /// Navigates the specified view to the region.
        /// </summary>
        /// <param name="regionName">The name of the region to call Navigate on.</param>
        /// <param name="viewName">The name of the view that registered for navigation inside manager.</param>
        /// <param name="navigationCallback">The navigation callback that will be executed after the navigation is completed.</param>
        /// <param name="navigationParameters">Navigation parameters to pass arguments between views.</param>
        void RequestNavigate(string regionName, string viewName, Action navigationCallback, INavigationParameters navigationParameters);
    }
}