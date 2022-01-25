namespace MagicMvvm;

public interface IMvvmBuilder
{
    /// <summary>
    /// Manually bind specified viewmodel to view
    /// </summary>
    /// <typeparam name="TView">View type</typeparam>
    /// <typeparam name="TViewModel">Viewmodel type</typeparam>
    /// <returns>The <see cref="IMvvmBuilder"/></returns>
    IMvvmBuilder WireViewModel<TView, TViewModel>() 
        where TView : VisualElement
        where TViewModel : ViewModelBase; 
}
