namespace MagicMvvm.Forms.Dialogs;

public static class DialogManagerExtensions
{
    /// <summary>
    /// Displays a dialog.
    /// </summary>
    /// <param name="dialogManager">Instance of <see cref="IDialogManager"/></param>
    /// <param name="name">The unique name of the dialog to display.</param>
    public static void ShowDialog(this IDialogManager dialogManager, string name)
    {
        dialogManager.ShowDialog(name, null, null);
    }
    
    /// <summary>
    /// Displays a dialog.
    /// </summary>
    /// <param name="dialogManager">Instance of <see cref="IDialogManager"/></param>
    /// <param name="name">The unique name of the dialog to display.</param>
    /// <param name="parameters">Parameters that the dialog can use for custom functionality.</param>
    /// <example>
    /// This example shows how to display a dialog with two parameters.
    /// <code>
    /// var parameters = new DialogParameters
    /// {
    ///     { "title", "Connection Lost!" },
    ///     { "message", "We seem to have lost network connectivity" }
    /// };
    /// _dialogManager.ShowDialog("DemoDialog", parameters);
    /// </code>
    /// </example>
    public static void ShowDialog(this IDialogManager dialogManager, string name, IParameters parameters)
    {
        dialogManager.ShowDialog(name, parameters, null);
    }
    
    /// <summary>
    /// Displays a dialog.
    /// </summary>
    /// <param name="dialogManager">Instance of <see cref="IDialogManager"/></param>
    /// <param name="name">The unique name of the dialog to display.</param>
    /// <param name="callback">The action to be invoked upon successful or failed completion of displaying the dialog.</param>
    public static void ShowDialog(this IDialogManager dialogManager, string name, Action<IDialogResult> callback)
    {
        dialogManager.ShowDialog(name, null, null);
    }

    /// <summary>
    /// Registers the dialog.
    /// </summary>
    /// <remarks>
    /// The name of dialog type <typeparamref name="T"/> will be used a unique name to display dialog
    /// </remarks>
    /// <param name="dialogManager">Instance of <see cref="IDialogManager"/></param>
    /// <typeparam name="T">View of dialog which is inherited from View</typeparam>
    /// <returns>The <see cref="IDialogManager"/>, for registering several dialogs easily.</returns>
    public static IDialogManager RegisterDialog<T>(this IDialogManager dialogManager) where T : View
    {
        var dialogName = typeof(T).Name;
        return dialogManager.RegisterDialog<T>(dialogName);
    }
}