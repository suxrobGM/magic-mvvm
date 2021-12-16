using MagicMvvm;

namespace AppDialogs.ViewModels.Dialogs
{
    public class DialogAViewModel : DialogViewModelBase
    {
        public DialogAViewModel()
        {
            Title = "Dialog A";
        }

        public override string Title { get; }
    }
}
