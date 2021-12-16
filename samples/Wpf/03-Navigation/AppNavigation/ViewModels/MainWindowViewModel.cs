using System.Windows.Input;
using MagicMvvm;
using MagicMvvm.Commands;
using MagicMvvm.Common;
using MagicMvvm.Navigation;

namespace AppNavigation.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Fields

        private readonly INavigationManager _navigationManager;

        #endregion

        #region Ctor

        public MainWindowViewModel(INavigationManager navigationManager)
        {
            // Resolves from container
            _navigationManager = navigationManager;

            // Assign action to command using DelegateCommand with command parameter type of string.
            NavigateCommand = new DelegateCommand<string>(NavigateToPage);
        }

        #endregion

        #region Commands

        public ICommand NavigateCommand { get; }

        #endregion

        #region Methods

        private void NavigateToPage(string page)
        {
            // Navigate to page view in the region which is "MainRegion"
            if (page == "A")
            {
                _navigationManager.RequestNavigate("MainRegion", "PageA");
            }
            else if (page == "B")
            {
                _navigationManager.RequestNavigate("MainRegion", "PageB");
            }
            else if (page == "C")
            {
                var navigationParameters = new Parameters()
                {
                    {"paramKey1", "paramValue1"},
                    {"paramKey2", "paramValue2"},
                    {"paramKey3", "paramValue3"},
                };
                _navigationManager.RequestNavigate("MainRegion", "PageC", navigationParameters);
            }
        }

        #endregion
    }
}
