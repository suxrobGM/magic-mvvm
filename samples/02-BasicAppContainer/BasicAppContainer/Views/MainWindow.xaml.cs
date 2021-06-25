using System.Windows;
using DryIoc;
using BasicAppContainer.ViewModels;

namespace BasicAppContainer.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // Resolve view model from container then bind to DataContext
            DataContext = App.Container.Resolve<MainWindowViewModel>();
            InitializeComponent();
        }
    }
}
