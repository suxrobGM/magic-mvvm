using MagicMvvm;

namespace BasicApp.Views;

public partial class MainPage : ContentPage, IWiredView
{
    public MainPage()
    {
        //Shell
        //BindingContext = MauiProgram.GetService<MainPageViewModel>();
        InitializeComponent();
    }
}