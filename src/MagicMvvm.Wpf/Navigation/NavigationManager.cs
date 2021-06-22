using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MagicMvvm.Navigation
{
    /// <summary>
    /// Implements <see cref="INavigationManager"/> to handle navigation between views.
    /// </summary>
    /// <remarks>
    /// Register type as a singleton inside container.
    /// </remarks>
    public class NavigationManager : INavigationManager
    {
        private readonly IDictionary<string, Uri> _viewsCollection;
        private readonly IDictionary<string, object> _regionsCollection;

        public NavigationManager()
        {
            _viewsCollection = new Dictionary<string, Uri>();
            _regionsCollection = new Dictionary<string, object>();
        }

        public INavigationManager RegisterRegionWithView(string regionName, object viewInstance)
        {
            if (string.IsNullOrEmpty(regionName))
                throw new ArgumentNullException(nameof(regionName));

            _regionsCollection.Add(regionName, viewInstance);
            return this;
        }

        public INavigationManager RegisterView(string viewName, Uri viewSource)
        {
            if (string.IsNullOrEmpty(viewName))
                throw new ArgumentNullException(nameof(viewName));

            _viewsCollection.Add(viewName, viewSource);
            return this;
        }

        public void RequestNavigate(string regionName, string viewName, Action navigationCallback,
            INavigationParameters navigationParameters)
        {
            if (!_viewsCollection.ContainsKey(viewName))
                throw new ArgumentException($"The name of view {viewName} was not registered inside registrar");

            if (!_regionsCollection.ContainsKey(regionName))
                throw new ArgumentException($"The name of region {regionName} was not registered inside registrar");

            var regionViewObj = _regionsCollection[regionName];
            var navContext = new NavigationContext(navigationParameters);
            var prevViewModelNavigationAware = ((regionViewObj as ContentControl)?.Content as ContentControl)?.DataContext as INavigationAware ??
                                               ((regionViewObj as ContentControl)?.Content as Page)?.DataContext as INavigationAware;

            prevViewModelNavigationAware?.OnNavigatedFrom(navContext);

            var viewObj = Application.LoadComponent(_viewsCollection[viewName]);
            var regionContent = regionViewObj.GetType().GetProperty("Content");
            regionContent?.SetValue(regionViewObj, viewObj);

            var nextViewModelNavigationAware = (viewObj as ContentControl)?.DataContext as INavigationAware ??
                                               (viewObj as Page)?.DataContext as INavigationAware;

            nextViewModelNavigationAware?.OnNavigatedTo(navContext);
            navigationCallback?.Invoke();
        }
    }
}