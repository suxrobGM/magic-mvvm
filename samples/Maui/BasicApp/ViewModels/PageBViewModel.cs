using MagicMvvm.Navigation;

namespace BasicApp.ViewModels;

internal class PageBViewModel : PageViewModelBase
{
    public PageBViewModel(INavigationManager navigationManager)
        : base(navigationManager)
    {
        LabelText = "Page B Content";
    }
}
