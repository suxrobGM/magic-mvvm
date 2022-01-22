using BasicApp.ViewModels;
namespace BasicApp.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        BindingContext = MauiProgram.GetService<MainPageViewModel>();
        InitializeComponent();
    }
}