namespace MagicMvvm.Forms.Navigation;

public class NavigationResult : INavigationResult
{
    public bool Success { get; set; }
    public Exception Exception { get; set; }
}