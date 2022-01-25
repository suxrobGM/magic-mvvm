using BasicApp.ViewModels;
using MagicMvvm;
using MagicMvvm.Attributes;

namespace BasicApp.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class PageA : ContentPage, IWiredView
{
	public PageA()
	{
		InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        OnPropertyChanged(nameof(BindingContext));
    }

    protected override void OnAppearing()
    {
        OnPropertyChanged(nameof(BindingContext));
    }
}