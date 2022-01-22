namespace MagicMvvm;

public interface IMvvmMauiBuilder
{
    public IMvvmMauiBuilder WireViewModel<TView, TViewModel>() 
        where TView : VisualElement
        where TViewModel : ViewModelBase;

    public IMvvmMauiBuilder RegisterPageForNavigation<TView>()
        where TView : Page;

    public IMvvmMauiBuilder RegisterDialog<TView>()
        where TView : View;
}
