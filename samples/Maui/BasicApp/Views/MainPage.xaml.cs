using BasicApp.ViewModels;
namespace BasicApp.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        Shell
        BindingContext = MauiProgram.GetService<MainPageViewModel>();
        InitializeComponent();
    }
}