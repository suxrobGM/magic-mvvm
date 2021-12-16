using MagicMvvm;

namespace AppDialogs.ViewModels.Dialogs
{
    public class DialogBViewModel : DialogViewModelBase
    {
        public DialogBViewModel()
        {
            Title = "Dialog B";
        }

        public override string Title { get; }
    }
}
