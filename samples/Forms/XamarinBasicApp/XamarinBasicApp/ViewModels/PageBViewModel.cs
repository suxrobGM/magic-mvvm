using MagicMvvm.Navigation;

namespace XamarinBasicApp.ViewModels;

internal class PageBViewModel : PageViewModelBase
{
    public PageBViewModel(INavigationManager navigationManager)
        : base(navigationManager)
    {
        LabelText = "Page B Content";
    }
}
