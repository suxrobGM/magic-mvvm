namespace MagicMvvm.Dialogs;

public interface IDialogResult
{
    Exception Exception { get; }
    IParameters Parameters { get; }
}