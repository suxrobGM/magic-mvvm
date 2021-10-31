using MagicMvvm;
using MagicMvvm.Navigation;

namespace AppNavigation.ViewModels.Pages
{
    public class PageCViewModel : ViewModelBase, INavigationAware
    {
        public PageCViewModel()
        {
            PageContent = "Page C content";
        }

        private string _pageContent;
        public string PageContent
        {
            get => _pageContent;
            set => SetProperty(ref _pageContent, value);
        }

        // Called when navigated to the current page
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            PageContent += "\nPage parameters:";

            // Tries to get navigation parameter where sent as key "paramKey1"
            if (navigationContext.Parameters.TryGetValue("paramKey1", out string paramValue1))
            {
                PageContent += $"\n{paramValue1}";
            }

            if (navigationContext.Parameters.TryGetValue("paramKey2", out string paramValue2))
            {
                PageContent += $"\n{paramValue2}";
            }

            if (navigationContext.Parameters.TryGetValue("paramKey3", out string paramValue3))
            {
                PageContent += $"\n{paramValue3}";
            }
        }

        // Called when navigated away from this page
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
