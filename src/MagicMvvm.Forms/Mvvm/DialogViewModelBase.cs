using MagicMvvm.Forms.Dialogs;

namespace MagicMvvm.Forms;

public abstract class DialogViewModelBase : BindableBase, IDialogAware
{
    public event Action<IParameters> RequestClose;
    
    public void CloseDialog(IParameters dialogParameters = null)
    {
        RequestClose?.Invoke(dialogParameters ?? new Parameters());
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