using MagicMvvm.Navigation;

namespace XamarinBasicApp.ViewModels;

internal class PageAViewModel : PageViewModelBase
{
    public PageAViewModel(INavigationManager navigationManager) 
        : base(navigationManager)
    {
        LabelText = "Page A Content";
    }
}