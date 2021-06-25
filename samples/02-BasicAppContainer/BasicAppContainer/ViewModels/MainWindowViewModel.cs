using MagicMvvm;

namespace BasicAppContainer.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Ctor

        public MainWindowViewModel()
        {
            Message = "Welcome to MagicMvvm sample basic application with container support (DryIoc container)";
        }

        #endregion

        #region Bindable properties

        private string _message;
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        #endregion
    }
}
