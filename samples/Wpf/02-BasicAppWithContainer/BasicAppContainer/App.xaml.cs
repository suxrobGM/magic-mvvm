using System.Windows;
using DryIoc;
using BasicAppContainer.ViewModels;
using BasicAppContainer.Views;

namespace BasicAppContainer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static readonly IContainer Container = new Container();

        protected override void OnStartup(StartupEventArgs e)
        {
            RegisterTypes();

            var mainWindow = Container.Resolve<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }

        // Register all types inside this method
        protected virtual void RegisterTypes()
        {
            // Register views
            Container.Register<MainWindow>(Reuse.Singleton);

            // Register view models
            Container.Register<MainWindowViewModel>(Reuse.Singleton);
        }
    }
}
