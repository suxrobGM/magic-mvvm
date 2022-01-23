using MagicMvvm;
using MagicMvvm.Commands;
using MagicMvvm.Navigation;

namespace BasicApp.ViewModels;

internal class PageAViewModel : ViewModelBase
{
    private readonly INavigationManager _navigationManager;

    public PageAViewModel(INavigationManager navigationManager)
    {
        _navigationManager = navigationManager;
        LabelText = "Page A Content";
        GoBackCommand = new DelegateCommand(async () => await GoBackAsync());
    }

    private string _labelText;
    public string LabelText
    {
        get => _labelText;
        set => SetProperty(ref _labelText, value);
    }

    public DelegateCommand GoBackCommand { get; }

    private async Task GoBackAsync()
    {
        await _navigationManager.GoBackAsync(null, null);
    }
}