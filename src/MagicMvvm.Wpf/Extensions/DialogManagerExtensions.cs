using System;
using System.Windows;

namespace MagicMvvm.Dialogs
{
    /// <summary>
    /// Extension methods for <see cref="IDialogManager"/>
    /// </summary>
    public static class DialogManagerExtensions
    {
        #region Register extension methods

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
        /// <exception cref="ArgumentNullException">Throws exception if <paramref name="dialogName"/> is null or empty</exception>
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
        /// <exception cref="ArgumentNullException">Throws exception if <paramref name="windowName"/> is null or empty</exception>
        /// <returns>The <see cref="IDialogManager"/>, for registering several host windows easily.</returns>
        public static IDialogManager RegisterDialogHostWindow<TDialogWindow>(this IDialogManager dialogManager, string windowName)
            where TDialogWindow : IDialogHostWindow
        {
            return dialogManager.RegisterDialogHostWindow<TDialogWindow>(windowName);
        }

        #endregion

        #region Show non-modal extension methods

        /// <summary>
        /// Shows a non-modal dialog.
        /// </summary>
        /// <param name="dialogManager">Instance of <see cref="IDialogManager"/></param>
        /// <param name="dialogName">The unique name of the dialog to show.</param>
        /// <exception cref="InvalidOperationException">Throws exception if <paramref name="dialogName"/> was not registered in internal registrar</exception>
        public static void Show(this IDialogManager dialogManager, string dialogName)
        {
            dialogManager.Show(dialogName, null, null, null);
        }

        /// <summary>
        /// Shows a non-modal dialog.
        /// </summary>
        /// <param name="dialogManager">Instance of <see cref="IDialogManager"/></param>
        /// <param name="dialogName">The unique name of the dialog to show.</param>
        /// <param name="parameters">The parameters to pass to the dialog.</param>
        /// <exception cref="InvalidOperationException">Throws exception if <paramref name="dialogName"/> was not registered in internal registrar</exception>
        public static void Show(this IDialogManager dialogManager, string dialogName, IDialogParameters parameters)
        {
            dialogManager.Show(dialogName, parameters, null, null);
        }

        /// <summary>
        /// Shows a non-modal dialog.
        /// </summary>
        /// <param name="dialogManager">Instance of <see cref="IDialogManager"/></param>
        /// <param name="dialogName">The unique name of the dialog to show.</param>
        /// <param name="callback">The action to perform when the dialog is closed.</param>
        /// <exception cref="InvalidOperationException">Throws exception if <paramref name="dialogName"/> was not registered in internal registrar</exception>
        public static void Show(this IDialogManager dialogManager, string dialogName, Action<IDialogResult> callback)
        {
            dialogManager.Show(dialogName, null, callback, null);
        }

        /// <summary>
        /// Shows a non-modal dialog.
        /// </summary>
        /// <param name="dialogManager">Instance of <see cref="IDialogManager"/></param>
        /// <param name="dialogName">The unique name of the dialog to show.</param>
        /// <param name="parameters">The parameters to pass to the dialog.</param>
        /// <param name="callback">The action to perform when the dialog is closed.</param>
        /// <exception cref="InvalidOperationException">Throws exception if <paramref name="dialogName"/> was not registered in internal registrar</exception>
        public static void Show(this IDialogManager dialogManager, string dialogName, IDialogParameters parameters,
            Action<IDialogResult> callback)
        {
            dialogManager.Show(dialogName, parameters, callback, null);
        }

        #endregion

        #region Show modal extension methods

        /// <summary>
        /// Shows a modal dialog.
        /// </summary>
        /// <param name="dialogManager">Instance of <see cref="IDialogManager"/></param>
        /// <param name="dialogName">The unique name of the dialog to show.</param>
        /// <exception cref="InvalidOperationException">Throws exception if <paramref name="dialogName"/> was not registered in internal registrar</exception>
        public static void ShowDialog(this IDialogManager dialogManager, string dialogName)
        {
            dialogManager.ShowDialog(dialogName, null, null, null);
        }

        /// <summary>
        /// Shows a modal dialog.
        /// </summary>
        /// <param name="dialogManager">Instance of <see cref="IDialogManager"/></param>
        /// <param name="dialogName">The unique name of the dialog to show.</param>
        /// <param name="parameters">>The parameters to pass to the dialog.</param>
        /// <exception cref="InvalidOperationException">Throws exception if <paramref name="dialogName"/> was not registered in internal registrar</exception>
        public static void ShowDialog(this IDialogManager dialogManager, string dialogName, IDialogParameters parameters)
        {
            dialogManager.ShowDialog(dialogName, parameters, null, null);
        }

        /// <summary>
        /// Shows a modal dialog.
        /// </summary>
        /// <param name="dialogManager">Instance of <see cref="IDialogManager"/></param>
        /// <param name="dialogName">The unique name of the dialog to show.</param>
        /// <param name="callback">The action to perform when the dialog is closed.</param>
        /// <exception cref="InvalidOperationException">Throws exception if <paramref name="dialogName"/> was not registered in internal registrar</exception>
        public static void ShowDialog(this IDialogManager dialogManager, string dialogName, Action<IDialogResult> callback)
        {
            dialogManager.ShowDialog(dialogName, null, callback, null);
        }

        /// <summary>
        /// Shows a modal dialog.
        /// </summary>
        /// <param name="dialogManager">Instance of <see cref="IDialogManager"/></param>
        /// <param name="dialogName">The unique name of the dialog to show.</param>
        /// <param name="parameters">The parameters to pass to the dialog.</param>
        /// <param name="callback">The action to perform when the dialog is closed.</param>
        /// <exception cref="InvalidOperationException">Throws exception if <paramref name="dialogName"/> was not registered in internal registrar</exception>
        public static void ShowDialog(this IDialogManager dialogManager, string dialogName, IDialogParameters parameters,
            Action<IDialogResult> callback)
        {
            dialogManager.ShowDialog(dialogName, parameters, callback, null);
        }

        #endregion
    }
}