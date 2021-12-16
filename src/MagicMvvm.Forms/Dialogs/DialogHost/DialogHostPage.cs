using System.Windows.Input;

namespace MagicMvvm.Dialogs;

internal class DialogHostPage: ContentPage, IDialogContainer
{
    public DialogHostPage()
    {
        AutomationId = "PrismDialogModal";
        BackgroundColor = Color.Transparent;
    }

    public View DialogView { get; set; }

    public ICommand Dismiss { get; set; }

    public event EventHandler<IDialogResult> DialogResult;

    public void RaiseDialogResult(IDialogResult result)
    {
        DialogResult?.Invoke(this, result);
    }
}