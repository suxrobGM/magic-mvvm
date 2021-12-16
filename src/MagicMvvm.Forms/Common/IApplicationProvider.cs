namespace MagicMvvm.Forms.Common;

/// <summary>
/// Defines a contract for providing Application components.
/// </summary>
public interface IApplicationProvider
{
    /// <summary>
    /// Gets the main page of the Application.
    /// </summary>
    Page MainPage { get; }

    /// <summary>
    /// Gets current shell.
    /// </summary>
    Shell CurrentShell { get; }
}