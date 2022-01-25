using MagicMvvm.Navigation;

namespace MagicMvvm;

/// <summary>
/// Base ViewModel
/// </summary>
public abstract class ViewModelBase : BindableBase, INavigationAware
{
    public virtual void OnNavigatedTo(IParameters parameters)
    {
    }

    public virtual void OnNavigatedFrom(IParameters parameters)
    {
    }
}