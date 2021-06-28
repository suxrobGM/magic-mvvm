using System;
using System.Windows;

namespace MagicMvvm.Navigation
{
    /// <summary>
    /// Extension methods for <see cref="INavigationManager"/>
    /// </summary>
    public static class NavigationManagerExtensions
    {
        #region Register extension methods

        /// <summary>
        /// Register view name and view source inside registrar. Configures specified view for navigation.
        /// </summary>
        /// <remarks>
        /// The name of type <typeparamref name="TView"/> will be used as a unique view name inside registrar.
        /// </remarks>
        /// <param name="navigationManager">Instance of <see cref="INavigationManager"/></param>
        /// <typeparam name="TView">Type of view. It will be used as a unique view name to register.</typeparam>
        /// <exception cref="InvalidOperationException">Throws exception if application does not have any resource files or could not locate to resource files</exception>
        /// <returns>The <see cref="INavigationManager"/>, for adding several views easily.</returns>
        public static INavigationManager RegisterView<TView>(this INavigationManager navigationManager)
            where TView : FrameworkElement
        {
            return navigationManager.RegisterView<TView>(typeof(TView).Name);
        }

        /// <summary>
        /// Register view name and view source inside registrar. Configures specified view for navigation.
        /// </summary>
        /// <remarks>
        /// The name of type <typeparamref name="TView"/> will be used as a unique view name inside registrar.
        /// </remarks>
        /// <param name="navigationManager">Instance of <see cref="INavigationManager"/></param>
        /// <param name="viewName">The unique view name to register.</param>
        /// <typeparam name="TView">Type of the view.</typeparam>
        /// <exception cref="ArgumentNullException">Throws exception if <paramref name="viewName"/> is null or empty</exception>
        /// <exception cref="InvalidOperationException">Throws exception if application does not have any resource files or could not locate to resource files</exception>
        /// <returns>The <see cref="INavigationManager"/>, for adding several views easily.</returns>
        public static INavigationManager RegisterView<TView>(this INavigationManager navigationManager, string viewName)
            where TView : FrameworkElement
        {
            return navigationManager.RegisterView<TView>(viewName);
        }

        #endregion

        #region Request navigate extension methods

        /// <summary>
        /// Navigates the specified view to the region.
        /// </summary>
        /// <param name="navigationManager">Instance of <see cref="INavigationManager"/></param>
        /// <param name="regionName">The name of the region to call Navigate on.</param>
        /// <param name="viewName">The name of the view that registered for navigation inside manager.</param>
        /// <exception cref="InvalidOperationException">Throws exception if <paramref name="viewName"/> or <paramref name="regionName"/> was not registered in internal registrar</exception>
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
        /// <exception cref="InvalidOperationException">Throws exception if <paramref name="viewName"/> or <paramref name="regionName"/> was not registered in internal registrar</exception>
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
        /// <exception cref="InvalidOperationException">Throws exception if <paramref name="viewName"/> or <paramref name="regionName"/> was not registered in internal registrar</exception>
        public static void RequestNavigate(this INavigationManager navigationManager, string regionName,
            string viewName, INavigationParameters navigationParameters)
        {
            navigationManager.RequestNavigate(regionName, viewName, null, navigationParameters);
        }

        #endregion
    }
}