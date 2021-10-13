using System;
using System.Collections.Generic;

namespace MagicMvvm.Navigation
{
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

            if (viewInstance == null)
                throw new ArgumentNullException(nameof(viewInstance));

            _regionsCollection.Add(regionName, viewInstance);
            return this;
        }

        public INavigationManager RegisterView<TView>(string viewName)
        {
            if (string.IsNullOrEmpty(viewName))
                throw new ArgumentNullException(nameof(viewName));
            
            
            
            return this;
        }

        public void RequestNavigate(string regionName, string viewName, Action navigationCallback,
            INavigationParameters navigationParameters)
        {
            throw new NotImplementedException();
        }
    }
}