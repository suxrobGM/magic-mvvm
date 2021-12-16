using MagicMvvm.Commands;
using System.Windows.Input;
using MagicMvvm;

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
        public override string Title { get; }
    }
}
