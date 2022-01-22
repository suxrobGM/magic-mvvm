using MagicMvvm.Dialogs;
using MagicMvvm.Navigation;

namespace MagicMvvm;

internal class MvvmMauiBuilder : IMvvmMauiBuilder
{
    private readonly IDialogManager _dialogManager;
    private readonly INavigationManager _navigationManager;

    public MvvmMauiBuilder(
        IDialogManager dialogManager, 
        INavigationManager navigationManager)
    {
        _dialogManager = dialogManager;
        _navigationManager = navigationManager;
    }

    public IMvvmMauiBuilder RegisterDialog<TView>() where TView : View
    {
        throw new NotImplementedException();
    }

    public IMvvmMauiBuilder RegisterPageForNavigation<TView>() where TView : Page
    {
        throw new NotImplementedException();
    }

    public IMvvmMauiBuilder WireViewModel<TView, TViewModel>()
        where TView : VisualElement
        where TViewModel : ViewModelBase
    {
        throw new NotImplementedException();
    }
}
