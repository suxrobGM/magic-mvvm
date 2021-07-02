using MagicMvvm;

namespace AppNavigation.ViewModels.Pages
{
    public class PageAViewModel : ViewModelBase
    {
        #region Ctor

        public PageAViewModel()
        {
            PageContent = "Page A content";
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
