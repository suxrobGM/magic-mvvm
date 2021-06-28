using System.Windows;
using DryIoc;
using MagicMvvm.Navigation;

using AppNavigation.ViewModels;
using AppNavigation.ViewModels.Pages;
using AppNavigation.Views;
using AppNavigation.Views.Pages;

namespace AppNavigation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Public fields

        // Readonly instance of DryIoc container.
        public static readonly IContainer Container = new Container();

        #endregion

        #region Lifecycle methods

        /// <summary>
        /// Application entry point.
        /// </summary>
        /// <param name="e">Args</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            // Call lifecycle methods.
            // Note: It's important to call RegisterTypes() method first of all.
            RegisterTypes();
            RegisterNavigation();

            // Resolve MainWindow from container then display main window.
            Container.Resolve<MainWindow>().Show();
            base.OnStartup(e);
        }

        /// <summary>
        /// Registers all data types in the container.
        /// </summary>
        protected virtual void RegisterTypes()
        {
            // Register INavigationManager service as a singleton.
            // Note: It's important to register as a singelton otherwise you will get different navigation managers when you try to navigate to views.
            Container.Register<INavigationManager, NavigationManager>(Reuse.Singleton);

            // Register views
            Container.Register<MainWindow>(Reuse.Singleton);
            Container.Register<PageA>(Reuse.Singleton);
            Container.Register<PageB>(Reuse.Singleton);

            // Register view models
            Container.Register<MainWindowViewModel>(Reuse.Singleton);
            Container.Register<PageAViewModel>(Reuse.Singleton);
            Container.Register<PageBViewModel>(Reuse.Singleton);
        }

        /// <summary>
        /// Registers all navigation views.
        /// </summary>
        protected virtual void RegisterNavigation()
        {
            // Resolve singleton instance of the navigation manager from container.
            var navigationManager = Container.Resolve<INavigationManager>();

            // Register all navigable views (pages, user controls etc) with unique names.
            // It will register navigation paths in internal registrar of the navigation manager.
            navigationManager.RegisterView<PageA>();
            navigationManager.RegisterView<PageB>();
        }

        #endregion
    }
}
