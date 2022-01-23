using MagicMvvm.AppModel;
using MagicMvvm.Dialogs;

namespace MagicMvvm.Navigation;

/// <summary>
/// Implements <see cref="IShellNavigationManager"/> to handle navigation between pages in the shell.
/// </summary>
/// <remarks>
/// Register type as a singleton if you are using IoC container.
/// </remarks>
public sealed class ShellNavigationManager : NavigationManager, IShellNavigationManager
{
    private readonly IDictionary<string, object> _shells;
    private IParameters _parameters;
    private bool _modalDialogPushed;
    private bool _modalDialogPopped;

    public ShellNavigationManager(IAppProvider appProvider) : base(appProvider)
    {
        _shells = new Dictionary<string, object>();
        _parameters = new Parameters();
    }

    public INavigationManager RegisterShell<T>(T instance)
        where T : Shell
    {
        var shellName = typeof(T).Name;

        if (instance is null)
            throw new ArgumentNullException(nameof(instance));

        if (_shells.ContainsKey(shellName))
            throw new ArgumentException($"Already registered shell {shellName}");

        _shells.Add(shellName, instance);
        RegisterShellEvents(instance);
        return this;
    }

    public override INavigationManager RegisterPage<T>(string pageName)
    {
        base.RegisterPage<T>(pageName);
        Routing.RegisterRoute(pageName, typeof(T));
        return this;
    }

    public override Task<INavigationResult> NavigateToAsync(string pageName, Action navigationCallback,
        IParameters parameters)
    {
        if (!_pages.ContainsKey(pageName))
            throw new InvalidOperationException($"The name of view {pageName} was not registered inside registrar");

        return NavigateToRouteAsync($"//{pageName}", navigationCallback, parameters);
    }

    public override Task<INavigationResult> GoBackAsync(Action navigationCallback, IParameters parameters)
    {
        return NavigateToRouteAsync("..", navigationCallback, parameters);
    }

    private async Task<INavigationResult> NavigateToRouteAsync(string route, Action navigationCallback,
        IParameters navigationParameters)
    {
        try
        {
            var currentShell = _appProvider.CurrentShell;
            var shellIsRegistered = _shells.Values.Contains(currentShell);
            var currentPage = currentShell.CurrentPage?.ToString();
            var pageName = string.Empty;

            if (route.StartsWith("//"))
                pageName = route[2..];

            if (!shellIsRegistered)
            {
                throw new InvalidOperationException(
                    $"The current shell {currentShell.GetType().Name} is not registered");
            }

            _parameters = navigationParameters;

            if (!string.IsNullOrEmpty(pageName) &&
                !string.IsNullOrEmpty(currentPage) &&
                currentPage.EndsWith(pageName))
            {
                var targetPageVM = currentShell.CurrentPage.BindingContext as INavigationAware;
                targetPageVM?.OnNavigatedFrom(_parameters);
                targetPageVM?.OnNavigatedTo(_parameters);
            }
            else
            {
                await currentShell.GoToAsync($"{route}{navigationParameters}");
            }

            navigationCallback?.Invoke();
            return new NavigationResult
            {
                Success = true,
                Exception = null
            };
        }
        catch (Exception e)
        {
            return new NavigationResult
            {
                Success = false,
                Exception = e
            };
        }
    }

    private void RegisterShellEvents(Shell shell)
    {
        if (shell == null)
            return;

        shell.Navigating += CurrentShellOnNavigating;
        shell.Navigated += CurrentShellOnNavigated;
    }

    private void CurrentShellOnNavigated(object sender, ShellNavigatedEventArgs e)
    {
        if (sender is not Shell shell)
            return;

        _modalDialogPushed = shell.CurrentPage.Navigation.ModalStack.Any(i => i is IDialogContainer);
        if (_modalDialogPushed)
        {
            return;
        }

        if (_modalDialogPopped)
        {
            _modalDialogPopped = false;
            return;
        }

        var targetPageVM = shell.CurrentPage.BindingContext as INavigationAware;
        targetPageVM?.OnNavigatedTo(_parameters);

        // clear old parameters
        if (_parameters.Count > 0)
        {
            _parameters = new Parameters();
        }
    }

    private void CurrentShellOnNavigating(object sender, ShellNavigatingEventArgs e)
    {
        if (sender is not Shell shell)
            return;

        _modalDialogPopped = shell.CurrentPage.Navigation.ModalStack.Any(i => i is IDialogContainer);
        if (_modalDialogPopped)
        {
            return;
        }

        if (_modalDialogPushed)
        {
            _modalDialogPushed = false;
            return;
        }
        var currentPageVM = shell.CurrentPage.BindingContext as INavigationAware;
        currentPageVM?.OnNavigatedFrom(_parameters);
    }
}