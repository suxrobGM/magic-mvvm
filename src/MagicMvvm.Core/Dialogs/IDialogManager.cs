using System;

namespace MagicMvvm.Dialogs
{
    /// <summary>
    /// Interface to show modal or non-modal dialogs.
    /// </summary>
    /// <remarks>
    /// Register type as a singleton inside container.
    /// </remarks>
    public interface IDialogManager
    {
        /// <summary>
        /// Register dialog inside registrar.
        /// </summary>
        /// <param name="dialogName">The unique name of the dialog.</param>
        /// <typeparam name="TDialogView">View of dialog which is inherited from FrameworkElement</typeparam>
        /// <returns>The <see cref="IDialogManager"/>, for registering several dialogs easily.</returns>
        IDialogManager RegisterDialog<TDialogView>(string dialogName);

        /// <summary>
        /// Register dialog host window inside registrar.
        /// </summary>
        /// <param name="windowName">The unique name of the dialog's hosting window.</param>
        /// <typeparam name="TDialogWindow">View of dialog's hosting window which is class that implements IDialogHostWindow</typeparam>
        /// <returns>The <see cref="IDialogManager"/>, for registering several host windows easily.</returns>
        IDialogManager RegisterDialogHostWindow<TDialogWindow>(string windowName);

        /// <summary>
        /// Shows a non-modal dialog.
        /// </summary>
        /// <param name="name">The unique name of the dialog to show.</param>
        /// <param name="parameters">The parameters to pass to the dialog.</param>
        /// <param name="callback">The action to perform when the dialog is closed.</param>
        /// <param name="windowName">The unique name of dialog's hosting window.</param>
        void Show(string name, IDialogParameters parameters, Action<IDialogResult> callback, string windowName);


        /// <summary>
        /// Shows a modal dialog.
        /// </summary>
        /// <param name="name">The unique name of the dialog to show.</param>
        /// <param name="parameters">The parameters to pass to the dialog.</param>
        /// <param name="callback">The action to perform when the dialog is closed.</param>
        /// <param name="windowName">The unique name of dialog's hosting window.</param>
        void ShowDialog(string name, IDialogParameters parameters, Action<IDialogResult> callback, string windowName);
    }
}