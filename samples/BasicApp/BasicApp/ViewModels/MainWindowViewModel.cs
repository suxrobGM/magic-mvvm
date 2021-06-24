using MagicMvvm;

namespace BasicApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Ctor

        public MainWindowViewModel()
        {
            Message = "Welcome to MagicMvvm sample basic application without container";
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
