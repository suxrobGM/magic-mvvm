using Xamarin.Forms;
using XamarinBasicApp.Views;

namespace XamarinBasicApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new MainPage();
    }

    protected override void OnStart()
    {
    }

    protected override void OnSleep()
    {
    }

    protected override void OnResume()
    {
    }
}
