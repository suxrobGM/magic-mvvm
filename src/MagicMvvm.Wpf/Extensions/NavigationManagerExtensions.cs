using System;
using System.Windows;

namespace MagicMvvm.Navigation
{
    /// <summary>
    /// Extension methods for <see cref="INavigationManager"/>
    /// </summary>
    public static class NavigationManagerExtensions
    {
        /// <summary>
        /// Register view name and view source inside registrar. Configures specified view for navigation.
        /// </summary>
        /// <param name="navigationManager">Instance of <see cref="INavigationManager"/></param>
        /// <param name="viewName">The view name to register.</param>
        /// <param name="viewSourceUri">The URI of specified view as a string representation.</param>
        /// <returns>The <see cref="INavigationManager"/>, for adding several views easily.</returns>
        public static INavigationManager RegisterView(this INavigationManager navigationManager, string viewName, string viewSourceUri)
        {
            return navigationManager.RegisterView(viewName, new Uri(viewSourceUri, UriKind.RelativeOrAbsolute));
        }

        /// <summary>
        /// Register view name and view source inside registrar. Configures specified view for navigation.
        /// </summary>
        /// <remarks>
        /// The name of type <typeparamref name="TView"/> will be used as a unique view name inside registrar.
        /// </remarks>
        /// <param name="navigationManager">Instance of <see cref="INavigationManager"/></param>
        /// <param name="viewSourceUri">The URI of specified view as a string representation</param>
        /// <typeparam name="TView">Type of the view. It will be used as a view name to register.</typeparam>
        /// <returns>The <see cref="INavigationManager"/>, for adding several views easily.</returns>
        public static INavigationManager RegisterView<TView>(this INavigationManager navigationManager, string viewSourceUri) 
            where TView : FrameworkElement
        {
            return navigationManager.RegisterView(typeof(TView).Name, new Uri(viewSourceUri, UriKind.RelativeOrAbsolute));
        }

        /// <summary>
        /// Register view name and view source inside registrar. Configures specified view for navigation.
        /// </summary>
        /// <remarks>
        /// The name of type <typeparamref name="TView"/> will be used as a unique view name inside registrar.
        /// </remarks>
        /// <param name="navigationManager">Instance of <see cref="INavigationManager"/></param>
        /// <param name="viewSource">The URI of specified view.</param>
        /// <typeparam name="TView">Type of view. It will be used as a view name to register.</typeparam>
        /// <returns>The <see cref="INavigationManager"/>, for adding several views easily.</returns>
        public static INavigationManager RegisterView<TView>(this INavigationManager navigationManager, Uri viewSource)
            where TView : FrameworkElement
        {
            return navigationManager.RegisterView(typeof(TView).Name, viewSource);
        }

        /// <summary>
        /// Navigates the specified view to the region.
        /// </summary>
        /// <param name="navigationManager">Instance of <see cref="INavigationManager"/></param>
        /// <param name="regionName">The name of the region to call Navigate on.</param>
        /// <param name="viewName">The name of the view that registered for navigation inside manager.</param>
        public static void RequestNavigate(this INavigationManager navigationManager, string regionName,
            string viewName)
        {
            navigationManager.RequestNavigate(regionName, viewName, null, null);
        }

        /// <summary>
        /// Navigates the specified view to the region.
        /// </summary>
        /// <param name="navigationManager">Instance of <see cref="INavigationManager"/></param>
        /// <param name="regionName">The name of the region to call Navigate on.</param>
        /// <param name="viewName">The name of the view that registered for navigation inside manager.</param>
        /// <param name="navigationCallback">The navigation callback that will be executed after the navigation is completed.</param>
        public static void RequestNavigate(this INavigationManager navigationManager, string regionName,
            string viewName, Action navigationCallback)
        {
            navigationManager.RequestNavigate(regionName, viewName, navigationCallback, null);
        }

        /// <summary>
        /// Navigates the specified view to the region.
        /// </summary>
        /// <param name="navigationManager">Instance of <see cref="INavigationManager"/></param>
        /// <param name="regionName">The name of the region to call Navigate on.</param>
        /// <param name="viewName">The name of the view that registered for navigation inside manager.</param>
        /// <param name="navigationParameters">Navigation parameters to pass arguments between views.</param>
        public static void RequestNavigate(this INavigationManager navigationManager, string regionName,
            string viewName, INavigationParameters navigationParameters)
        {
            navigationManager.RequestNavigate(regionName, viewName, null, navigationParameters);
        }
    }
}