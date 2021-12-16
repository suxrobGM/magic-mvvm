using System.Threading.Tasks;
using MagicMvvm;
using MagicMvvm.Common;

namespace AppDialogs.ViewModels.Dialogs
{
    public class DialogCViewModel : DialogViewModelBase
    {
        public DialogCViewModel()
        {
            Title = "Dialog C";
        }

        public override async void OnDialogOpened(IParameters parameters)
        {
            // Auto close dialog after performing some long-running actions
            await Task.Delay(4000);
            CloseDialog();
        }

        public override string Title { get; }
    }
}
