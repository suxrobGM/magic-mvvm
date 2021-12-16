namespace MagicMvvm.Forms.Dialogs;

/// <summary>
/// Interface to show dialogs.
/// </summary>
/// <remarks>
/// Register type as a singleton inside container.
/// </remarks>
public interface IDialogManager
{
    /// <summary>
    /// Displays a dialog.
    /// </summary>
    /// <param name="name">The unique name of the dialog to display.</param>
    /// <param name="parameters">Parameters that the dialog can use for custom functionality.</param>
    /// <param name="callback">The action to be invoked upon successful or failed completion of displaying the dialog.</param>
    /// <example>
    /// This example shows how to display a dialog with two parameters.
    /// <code>
    /// var parameters = new DialogParameters
    /// {
    ///     { "title", "Connection Lost!" },
    ///     { "message", "We seem to have lost network connectivity" }
    /// };
    /// _dialogManager.ShowDialog("DemoDialog", parameters, <paramref name="callback"/>: null);
    /// </code>
    /// </example>
    void ShowDialog(string name, IParameters parameters, Action<IDialogResult> callback);

    /// <summary>
    /// Registers the dialog.
    /// </summary>
    /// <param name="dialogName">The unique name of the dialog.</param>
    /// <typeparam name="T">View of dialog which is inherited from View</typeparam>
    /// <exception cref="ArgumentNullException">Throws exception if <paramref name="dialogName"/> is null or empty</exception>
    /// <returns>The <see cref="IDialogManager"/>, for registering several dialogs easily.</returns>
    IDialogManager RegisterDialog<T>(string dialogName) where T : View;
}