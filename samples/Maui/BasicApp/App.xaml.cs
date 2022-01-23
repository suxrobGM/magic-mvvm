using BasicApp.Views;

namespace BasicApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // Hierarchical Navigation
        MainPage = new NavigationPage(MauiProgram.GetService<MainPage>());
    }
}