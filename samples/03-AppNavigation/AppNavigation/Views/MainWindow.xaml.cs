using System.Windows;
using DryIoc;
using MagicMvvm.Navigation;
using AppNavigation.ViewModels;

namespace AppNavigation.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // Bind view model to DataContext
            DataContext = App.Container.Resolve<MainWindowViewModel>();

            // Initialize visual components
            InitializeComponent();

            // Resolve navigation manager from container
            var navigationManager = App.Container.Resolve<INavigationManager>();

            // Register navigtion region with unique name and its view instance
            navigationManager.RegisterRegionWithView("MainRegion", this.mainFrame);

            // Navigate to view "PageA" inside region "MainRegion"
            navigationManager.RequestNavigate("MainRegion", "PageA");
        }
    }
}
