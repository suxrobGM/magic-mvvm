using MagicMvvm;
using MagicMvvm.Commands;
using MagicMvvm.Common;
using MagicMvvm.Navigation;
using System.Threading.Tasks;

namespace XamarinBasicApp.ViewModels;

internal class MainPageViewModel : ViewModelBase
{
    private readonly INavigationManager _navigationManager;
    private int _count;

    public MainPageViewModel(INavigationManager navigationManager)
    {
        _navigationManager = navigationManager;
        CounterText = "Current count: 0";
        CounterCommand = new DelegateCommand(IncrementCounter);
        GoToPageCommand = new DelegateCommand<string>(async (i) => await GoToPageAsync(i));
    }

    #region Binding properties

    private string _counterText;
    public string CounterText
    {
        get => _counterText;
        set => SetProperty(ref _counterText, value);
    }

    #endregion

    #region Commands

    public DelegateCommand CounterCommand { get; }
    public DelegateCommand<string> GoToPageCommand { get; }

    #endregion


    private void IncrementCounter()
    {
        _count++;
        CounterText = $"Current count: {_count}";
    }

    private async Task GoToPageAsync(string page)
    {
        await _navigationManager.NavigateToAsync(page, null, null);
    }

    public override void OnNavigatedFrom(IParameters parameters)
    {
        base.OnNavigatedFrom(parameters);
    }

    public override void OnNavigatedTo(IParameters parameters)
    {
        base.OnNavigatedTo(parameters);
    }
}
