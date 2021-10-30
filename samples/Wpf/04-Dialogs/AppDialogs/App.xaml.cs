using System.Windows;
using DryIoc;
using MagicMvvm.Dialogs;
using AppDialogs.ViewModels;
using AppDialogs.ViewModels.Dialogs;
using AppDialogs.Views;
using AppDialogs.Views.Dialogs;

namespace AppDialogs
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
            RegisterDialogs();

            // Resolve MainWindow from container then display main window.
            Container.Resolve<MainWindow>().Show();
            base.OnStartup(e);
        }

        /// <summary>
        /// Registers all data types in the container.
        /// </summary>
        protected virtual void RegisterTypes()
        {
            // Register IDialogManager service as a singleton.
            // Note: It's important to register as a singelton otherwise you will get different instance of managers.
            Container.Register<IDialogManager, DialogManager>(Reuse.Singleton);

            // Register main window
            Container.Register<MainWindow>(Reuse.Singleton);

            // Register view models
            Container.Register<MainWindowViewModel>(Reuse.Singleton);
            Container.Register<DialogAViewModel>(Reuse.Singleton);
            Container.Register<DialogBViewModel>(Reuse.Singleton);
            Container.Register<DialogCViewModel>(Reuse.Singleton);
            Container.Register<DialogDViewModel>(Reuse.Singleton);
        }

        /// <summary>
        /// Registers all dialog views.
        /// </summary>
        protected virtual void RegisterDialogs()
        {
            // Resolve singleton instance of the dialog manager from container.
            var dialogManager = Container.Resolve<IDialogManager>();

            // Register all dialog views with unique names.
            // The name of the view type used as a unique dialog name in internal registrar.
            dialogManager.RegisterDialog<DialogA>();
            dialogManager.RegisterDialog<DialogB>();
            dialogManager.RegisterDialog<DialogC>();
            dialogManager.RegisterDialog<DialogD>();
        }

        #endregion
    }
}
