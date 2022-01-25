using DryIoc;
using MagicMvvm.Navigation;
using Xamarin.Forms;
using XamarinBasicApp.ViewModels;
using XamarinBasicApp.Views;

namespace XamarinBasicApp;

public partial class App : Application
{
    public static readonly IContainer Container = new Container();
    private static bool alreadyRegistered;

    public App()
    {
        InitializeComponent();
        RegisterTypes();
        MainPage = new NavigationPage(Container.Resolve<MainPage>());
    }

    public void RegisterTypes()
    {
        if (alreadyRegistered)
            return;

        Container.Register<MainPage>(Reuse.Singleton);
        Container.Register<PageA>(Reuse.Singleton);
        Container.Register<PageB>(Reuse.Singleton);
        Container.Register<MainPageViewModel>(Reuse.Singleton);
        Container.Register<PageAViewModel>(Reuse.Singleton);
        Container.Register<PageBViewModel>(Reuse.Singleton);
        Container.Register<INavigationManager, NavigationManager>(Reuse.Singleton);

        RegisterNavigation();
        alreadyRegistered = true;
    }

    public void RegisterNavigation()
    {
        var navigationManager = Container.Resolve<INavigationManager>();
        navigationManager.RegisterPage<PageA>();
        navigationManager.RegisterPage<PageB>();
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
