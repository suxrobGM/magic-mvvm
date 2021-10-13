using MagicMvvm.Dialogs;

namespace AppDialogs.ViewModels.Dialogs
{
    public class DialogAViewModel : DialogViewModelBase
    {
        public DialogAViewModel()
        {
            Title = "Dialog A";
        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            //await Task.Delay(4000);
            //CloseDialog();
        }
    }
}
