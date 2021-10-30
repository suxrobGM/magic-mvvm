using MagicMvvm.Commands;
using System.Windows.Input;

namespace AppDialogs.ViewModels.Dialogs
{
    public class DialogDViewModel : DialogViewModelBase
    {
        public DialogDViewModel()
        {
            Title = "Dialog D";
            CloseDialogCommand = new DelegateCommand(() => CloseDialog());
        }

        public ICommand CloseDialogCommand { get;}
    }
}
