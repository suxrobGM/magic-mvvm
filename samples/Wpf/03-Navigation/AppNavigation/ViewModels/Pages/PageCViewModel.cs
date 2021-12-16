using MagicMvvm;
using MagicMvvm.Common;

namespace AppNavigation.ViewModels.Pages
{
    public class PageCViewModel : ViewModelBase
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
        public override void OnNavigatedTo(IParameters parameters)
        {
            PageContent += "\nPage parameters:";

            // Tries to get navigation parameter where sent as key "paramKey1"
            if (parameters.TryGetValue("paramKey1", out string paramValue1))
            {
                PageContent += $"\n{paramValue1}";
            }

            if (parameters.TryGetValue("paramKey2", out string paramValue2))
            {
                PageContent += $"\n{paramValue2}";
            }

            if (parameters.TryGetValue("paramKey3", out string paramValue3))
            {
                PageContent += $"\n{paramValue3}";
            }
        }

        // Called when navigated away from this page
        public override void OnNavigatedFrom(IParameters parameters)
        {
        }
    }
}
