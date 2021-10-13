using System.Windows;
using DryIoc;
using AppDialogs.ViewModels;

namespace AppDialogs.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = App.Container.Resolve<MainWindowViewModel>();
            InitializeComponent();
        }
    }
}
