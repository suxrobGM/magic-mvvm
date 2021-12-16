using MagicMvvm.Dialogs;

namespace MagicMvvm;

/// <summary>
/// Base view model for dialogs.
/// </summary>
public abstract class DialogViewModelBase : IDialogAware
{
    public abstract string Title { get; }
    public event Action<IDialogResult> RequestClose;

    public void CloseDialog(IDialogResult dialogResult = null)
    {
        RequestClose?.Invoke(dialogResult ?? new DialogResult());
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