using System.Windows;
using BasicApp.Views;
using BasicApp.ViewModels;

namespace BasicApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = new MainWindow(new MainWindowViewModel());
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}
