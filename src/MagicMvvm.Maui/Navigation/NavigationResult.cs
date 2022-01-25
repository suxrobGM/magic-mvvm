namespace MagicMvvm.Navigation;

public class NavigationResult : INavigationResult
{
    public bool Success { get; set; }
    public Exception Exception { get; set; }
}