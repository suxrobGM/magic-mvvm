using MagicMvvm.Dialogs;

namespace MagicMvvm;

public abstract class DialogViewModelBase : BindableBase, IDialogAware
{
    public event Action<IParameters> RequestClose;
    
    public void CloseDialog(IParameters parameters = null)
    {
        RequestClose?.Invoke(parameters ?? new Parameters());
    }
    
    public virtual bool CanCloseDialog()
    {
        return true;
    }

    public virtual void OnDialogClosed()
    {
    }

    public virtual void OnDialogOpened(IParameters parameters)
    {
    }
}