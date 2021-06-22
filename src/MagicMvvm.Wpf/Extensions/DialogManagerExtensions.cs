using System;
using System.Windows;

namespace MagicMvvm.Dialogs
{
    /// <summary>
    /// Extension methods for <see cref="IDialogManager"/>
    /// </summary>
    public static class DialogManagerExtensions
    {
        /// <summary>
        /// Register dialog inside registrar.
        /// </summary>
        /// <remarks>
        /// The name of type <typeparamref name="TDialogView"/> will be used as a unique dialog name inside registrar.
        /// </remarks>
        /// <param name="dialogManager">Instance of <see cref="IDialogManager"/></param>
        /// <typeparam name="TDialogView">View of dialog which is inherited from <see cref="FrameworkElement"/></typeparam>
        /// <returns>The <see cref="IDialogManager"/>, for registering several dialogs easily.</returns>
        public static IDialogManager RegisterDialog<TDialogView>(this IDialogManager dialogManager)
            where TDialogView : FrameworkElement
        {
            return dialogManager.RegisterDialog<TDialogView>(typeof(TDialogView).Name);
        }

        /// <summary>
        /// Register dialog inside registrar.
        /// </summary>
        /// <param name="dialogManager">Instance of <see cref="IDialogManager"/></param>
        /// <param name="dialogName">The unique name of the dialog.</param>
        /// <typeparam name="TDialogView">View of dialog which is inherited from <see cref="FrameworkElement"/></typeparam>
        /// <returns>The <see cref="IDialogManager"/>, for registering several dialogs easily.</returns>
        public static IDialogManager RegisterDialog<TDialogView>(this IDialogManager dialogManager, string dialogName)
            where TDialogView : FrameworkElement
        {
            return dialogManager.RegisterDialog<TDialogView>(dialogName);
        }

        /// <summary>
        /// Register dialog host window inside registrar.
        /// </summary>
        /// <param name="dialogManager">Instance of <see cref="IDialogManager"/></param>
        /// <param name="windowName">The unique name of the dialog's hosting window.</param>
        /// <typeparam name="TDialogWindow">View of dialog's hosting window which is class that implements <see cref="IDialogHostWindow"/></typeparam>
        /// <returns>The <see cref="IDialogManager"/>, for registering several host windows easily.</returns>
        public static IDialogManager RegisterDialogHostWindow<TDialogWindow>(this IDialogManager dialogManager, string windowName)
            where TDialogWindow : IDialogHostWindow
        {
            return dialogManager.RegisterDialogHostWindow<TDialogWindow>(windowName);
        }

        /// <summary>
        /// Shows a non-modal dialog.
        /// </summary>
        /// <param name="dialogManager">Instance of <see cref="IDialogManager"/></param>
        /// <param name="name">The unique name of the dialog to show.</param>
        public static void Show(this IDialogManager dialogManager, string name)
        {
            dialogManager.Show(name, null, null, null);
        }

        /// <summary>
        /// Shows a non-modal dialog.
        /// </summary>
        /// <param name="dialogManager">Instance of <see cref="IDialogManager"/></param>
        /// <param name="name">The unique name of the dialog to show.</param>
        /// <param name="parameters">The parameters to pass to the dialog.</param>
        public static void Show(this IDialogManager dialogManager, string name, IDialogParameters parameters)
        {
            dialogManager.Show(name, parameters, null, null);
        }

        /// <summary>
        /// Shows a non-modal dialog.
        /// </summary>
        /// <param name="dialogManager">Instance of <see cref="IDialogManager"/></param>
        /// <param name="name">The unique name of the dialog to show.</param>
        /// <param name="callback">The action to perform when the dialog is closed.</param>
        public static void Show(this IDialogManager dialogManager, string name, Action<IDialogResult> callback)
        {
            dialogManager.Show(name, null, callback, null);
        }

        /// <summary>
        /// Shows a non-modal dialog.
        /// </summary>
        /// <param name="dialogManager">Instance of <see cref="IDialogManager"/></param>
        /// <param name="name">The unique name of the dialog to show.</param>
        /// <param name="parameters">The parameters to pass to the dialog.</param>
        /// <param name="callback">The action to perform when the dialog is closed.</param>
        public static void Show(this IDialogManager dialogManager, string name, IDialogParameters parameters,
            Action<IDialogResult> callback)
        {
            dialogManager.Show(name, parameters, callback, null);
        }

        /// <summary>
        /// Shows a modal dialog.
        /// </summary>
        /// <param name="dialogManager">Instance of <see cref="IDialogManager"/></param>
        /// <param name="name">The unique name of the dialog to show.</param>
        public static void ShowDialog(this IDialogManager dialogManager, string name)
        {
            dialogManager.ShowDialog(name, null, null, null);
        }

        /// <summary>
        /// Shows a modal dialog.
        /// </summary>
        /// <param name="dialogManager">Instance of <see cref="IDialogManager"/></param>
        /// <param name="name">The unique name of the dialog to show.</param>
        /// <param name="parameters">>The parameters to pass to the dialog.</param>
        public static void ShowDialog(this IDialogManager dialogManager, string name, IDialogParameters parameters)
        {
            dialogManager.ShowDialog(name, parameters, null, null);
        }

        /// <summary>
        /// Shows a modal dialog.
        /// </summary>
        /// <param name="dialogManager">Instance of <see cref="IDialogManager"/></param>
        /// <param name="name">The unique name of the dialog to show.</param>
        /// <param name="callback">The action to perform when the dialog is closed.</param>
        public static void ShowDialog(this IDialogManager dialogManager, string name, Action<IDialogResult> callback)
        {
            dialogManager.ShowDialog(name, null, callback, null);
        }

        /// <summary>
        /// Shows a modal dialog.
        /// </summary>
        /// <param name="dialogManager">Instance of <see cref="IDialogManager"/></param>
        /// <param name="name">The unique name of the dialog to show.</param>
        /// <param name="parameters">The parameters to pass to the dialog.</param>
        /// <param name="callback">The action to perform when the dialog is closed.</param>
        public static void ShowDialog(this IDialogManager dialogManager, string name, IDialogParameters parameters,
            Action<IDialogResult> callback)
        {
            dialogManager.ShowDialog(name, parameters, callback, null);
        }
    }
}