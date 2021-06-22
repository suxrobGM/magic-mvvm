using System;

namespace MagicMvvm.Navigation
{
    /// <summary>
    /// Encapsulates information about a navigation request.
    /// </summary>
    public class NavigationContext
    {
        
        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationContext"/> class for a region name and a 
        /// <see cref="Uri"/>.
        /// </summary>
        /// <param name="navigationParameters">The navigation parameters.</param>
        public NavigationContext(INavigationParameters navigationParameters)
        {
            Parameters = navigationParameters ?? new NavigationParameters();
        }

        /// <summary>
        /// Gets the <see cref="NavigationParameters"/> extracted from the URI and the object parameters passed in navigation.
        /// </summary>
        /// <value>The URI query.</value>
        public INavigationParameters Parameters { get; }
        
    }
    
}