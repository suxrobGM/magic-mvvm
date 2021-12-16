namespace MagicMvvm.Forms.Common;

/// <summary>
/// Provides Application components.
/// </summary>
internal class ApplicationProvider : IApplicationProvider
{
    public Page MainPage => Application.Current?.MainPage;
    public Shell CurrentShell => Shell.Current;
}