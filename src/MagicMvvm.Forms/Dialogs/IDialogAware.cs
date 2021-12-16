namespace MagicMvvm.Dialogs;

public interface IDialogAware
{
    bool CanCloseDialog();
    void OnDialogClosed();
    void OnDialogOpened(IParameters parameters);
    event Action<IParameters> RequestClose;
}