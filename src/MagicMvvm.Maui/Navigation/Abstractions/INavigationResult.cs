namespace MagicMvvm.Navigation;

/// <summary>
/// Describes navigation result.
/// </summary>
public interface INavigationResult
{
    bool Success { get; }

    Exception Exception { get; }
}