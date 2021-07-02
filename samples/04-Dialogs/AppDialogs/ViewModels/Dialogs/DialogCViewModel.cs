using System.Threading.Tasks;
using MagicMvvm.Dialogs;

namespace AppDialogs.ViewModels.Dialogs
{
    public class DialogCViewModel : DialogViewModelBase
    {
        public DialogCViewModel()
        {
            Title = "Dialog C";
        }

        public async override void OnDialogOpened(IDialogParameters parameters)
        {
            // Auto close dialog after performing some long-running actions
            await Task.Delay(4000);
            CloseDialog();
        }
    }
}
