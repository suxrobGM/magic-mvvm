using MagicMvvm;

namespace BasicApp.ViewModels;

internal class PageBViewModel : ViewModelBase
{
    public PageBViewModel()
    {
        LabelText = "Page B Content";
    }

    private string _labelText;
    public string LabelText
    {
        get => _labelText;
        set => SetProperty(ref _labelText, value);
    }
}
