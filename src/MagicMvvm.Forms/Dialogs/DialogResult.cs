namespace MagicMvvm.Forms.Dialogs;

internal class DialogResult : IDialogResult
{
    public Exception Exception { get; set; }
    public IParameters Parameters { get; set; }
}