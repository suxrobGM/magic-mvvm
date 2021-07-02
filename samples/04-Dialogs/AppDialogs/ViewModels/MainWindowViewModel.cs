using System.Windows.Input;
using MagicMvvm;
using MagicMvvm.Commands;
using MagicMvvm.Dialogs;

namespace AppDialogs.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Fields

        private readonly IDialogManager _dialogManager;

        #endregion

        #region Constructor

        public MainWindowViewModel(IDialogManager dialogManager)
        {
            // Resolves from container
            _dialogManager = dialogManager;

            // Assign action to command using DelegateCommand with command parameter type of string.
            ShowDialogCommand = new DelegateCommand<string>(ShowDialog);
        }

        #endregion

        #region Commands

        public ICommand ShowDialogCommand { get; }

        #endregion

        #region Methods

        private void ShowDialog(string dialog)
        {
            // Navigate to page view in the region which is "MainRegion"
            if (dialog == "A")
            {
                // Show modal dialog "DialogA"
                _dialogManager.ShowDialog("DialogA");
            }
            else if (dialog == "B")
            {
                // Show non-modal dialog "DialogB"
                _dialogManager.Show("DialogB");
            }
            else if (dialog == "C")
            {
                // Show modal dialog "DialogC"
                _dialogManager.ShowDialog("DialogC");
            }
        }

        #endregion
    }
}
