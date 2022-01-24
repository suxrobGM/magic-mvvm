using MagicMvvm;
using MagicMvvm.Commands;
using MagicMvvm.Common;
using MagicMvvm.Navigation;

namespace BasicApp.ViewModels;

internal abstract class PageViewModelBase : ViewModelBase
{
    protected readonly INavigationManager _navigationManager;

    protected PageViewModelBase(INavigationManager navigationManager)
    {
        _navigationManager = navigationManager;
        GoBackCommand = new DelegateCommand(async () => await GoBackAsync());
    }

    #region Binding properties

    private string _labelText;
    public string LabelText
    {
        get => _labelText;
        set => SetProperty(ref _labelText, value);
    }

    #endregion

    #region Commands

    public DelegateCommand GoBackCommand { get; }

    #endregion 

    private async Task GoBackAsync()
    {
        await _navigationManager.GoBackAsync(null, null);
    }

    #region Navigation Events

    public override void OnNavigatedFrom(IParameters parameters)
    {
        base.OnNavigatedFrom(parameters);
    }

    public override void OnNavigatedTo(IParameters parameters)
    {
        base.OnNavigatedTo(parameters);
    }

    #endregion
}
