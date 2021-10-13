using MagicMvvm;

namespace AppNavigation.ViewModels.Pages
{
    public class PageBViewModel : ViewModelBase
    {
        #region Ctor

        public PageBViewModel()
        {
            PageContent = "Page B content";
        }

        #endregion


        #region Bindable properties

        private string _pageContent;
        public string PageContent
        {
            get => _pageContent;
            set => SetProperty(ref _pageContent, value);
        }

        #endregion
    }
}
