using MagicMvvm;
using MagicMvvm.Commands;

namespace BasicApp.ViewModels;

internal class MainPageViewModel : ViewModelBase
{
    private int count;

    public MainPageViewModel()
    {
        CounterText = "Current count: 0";
        CounterCommand = new DelegateCommand(() =>
        {
            count++;
            CounterText = $"Current count: {count}";
        });
    }

    #region Binding properties

    private string _counterText;
    public string CounterText
    {
        get => _counterText;
        set => SetProperty(ref _counterText, value);
    }

    #endregion


    public DelegateCommand CounterCommand { get; }
}
