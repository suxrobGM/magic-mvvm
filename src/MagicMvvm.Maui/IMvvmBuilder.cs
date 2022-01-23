namespace MagicMvvm;

public interface IMvvmBuilder
{
    IMvvmBuilder WireViewModel<TView, TViewModel>() 
        where TView : VisualElement
        where TViewModel : ViewModelBase;

    IMvvmBuilder RegisterPageForNavigation<TView>(string pageName) where TView : Page;
    IMvvmBuilder RegisterDialog<TView>(string dialogName) where TView : View;
    IMvvmBuilder RegisterShell<TView>(TView instance) where TView : Shell;
}
