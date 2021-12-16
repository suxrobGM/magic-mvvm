﻿namespace MagicMvvm.Dialogs;

/// <summary>
/// An <see cref="IDialogResult"/> that contains <see cref="IParameters"/> from the dialog
/// and the <see cref="ButtonResult"/> of the dialog.
/// </summary>
public class DialogResult : IDialogResult
{
    /// <summary>
    /// The parameters from the dialog.
    /// </summary>
    public IParameters Parameters { get; } = new Parameters();

    /// <summary>
    /// The result of the dialog.
    /// </summary>
    public ButtonResult Result { get; private set; } = ButtonResult.None;

    /// <summary>
    /// Initializes a new instance of the <see cref="DialogResult"/> class.
    /// </summary>
    public DialogResult() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="DialogResult"/> class.
    /// </summary>
    /// <param name="result">The result of the dialog.</param>
    public DialogResult(ButtonResult result)
    {
        Result = result;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DialogResult"/> class.
    /// </summary>
    /// <param name="result">The result of the dialog.</param>
    /// <param name="parameters">The parameters from the dialog.</param>
    public DialogResult(ButtonResult result, IParameters parameters)
    {
        Result = result;
        Parameters = parameters;
    }
}