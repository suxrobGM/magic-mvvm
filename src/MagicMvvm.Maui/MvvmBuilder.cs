using MagicMvvm.AppModel;

namespace MagicMvvm;

internal class MvvmBuilder : IMvvmBuilder
{
    private readonly IAppProvider _appProvider;

    public MvvmBuilder(IAppProvider appProvider)
    {
        _appProvider = appProvider;
    }

    public IMvvmBuilder WireViewModel<TView, TViewModel>()
        where TView : VisualElement
        where TViewModel : ViewModelBase
    {
        var view = _appProvider.ServiceProvider.GetRequiredService<TView>();
        view.BindingContext = _appProvider.ServiceProvider.GetRequiredService<TViewModel>();
        return this;
    }
}
