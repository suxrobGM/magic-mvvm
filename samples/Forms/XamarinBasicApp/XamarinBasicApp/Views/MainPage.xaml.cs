using DryIoc;
using Xamarin.Forms;
using XamarinBasicApp.ViewModels;

namespace XamarinBasicApp.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = App.Container.Resolve<MainPageViewModel>();
    }
}
