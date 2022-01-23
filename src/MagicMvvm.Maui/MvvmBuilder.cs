using MagicMvvm.AppModel;
using MagicMvvm.Dialogs;
using MagicMvvm.Navigation;
using MagicMvvm.Options;

namespace MagicMvvm;

internal class MvvmBuilder : IMvvmBuilder
{
    private readonly IAppProvider _appProvider;
    private readonly IDialogManager _dialogManager;
    private readonly INavigationManager _navigationManager;
    private readonly IShellNavigationManager _shellNavigationManager;
    private readonly MvvmOptions _mvvmOptions;

    public MvvmBuilder(
        IAppProvider appProvider,
        IDialogManager dialogManager, 
        INavigationManager navigationManager,
        IShellNavigationManager shellNavigationManager,
        MvvmOptions mvvmOptions)
    {
        _appProvider = appProvider;
        _dialogManager = dialogManager;
        _navigationManager = navigationManager;
        _shellNavigationManager = shellNavigationManager;
        _mvvmOptions = mvvmOptions;
    }

    public IMvvmBuilder RegisterDialog<TView>(string dialogName) where TView : View
    {
        _dialogManager.RegisterDialog<TView>(dialogName);
        return this;
    }

    public IMvvmBuilder RegisterPageForNavigation<TView>(string pageName) where TView : Page
    {
        if (_mvvmOptions.UseShellNavigation)
        {
            _shellNavigationManager.RegisterPage<TView>(pageName);
        }
        else
        {
            _navigationManager.RegisterPage<TView>(pageName);
        }

        return this;
    }

    public IMvvmBuilder RegisterShell<TView>(TView instance) where TView : Shell
    {
        _shellNavigationManager.RegisterShell(instance);
        return this;
    }

    public IMvvmBuilder WireViewModel<TView, TViewModel>()
        where TView : VisualElement
        where TViewModel : ViewModelBase
    {
        var view = _appProvider.ServiceProvider.GetService<TView>();
        view.BindingContext = _appProvider.ServiceProvider.GetService<TViewModel>();
        return this;
    }
}
