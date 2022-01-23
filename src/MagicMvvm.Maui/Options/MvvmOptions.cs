namespace MagicMvvm.Options;

public class MvvmOptions
{
    /// <summary>
    /// Automatically wires viewmodels to views
    /// </summary>
    public bool AutoWireViewModels { get; set; } = true;

    /// <summary>
    /// Uses shell navigation instead usual page navigation
    /// </summary>
    public bool UseShellNavigation { get; set; }
}
