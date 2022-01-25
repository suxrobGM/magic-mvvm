using DryIoc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinBasicApp.ViewModels;

namespace XamarinBasicApp.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class PageB : ContentPage
{
    public PageB()
    {
        InitializeComponent();
        BindingContext = App.Container.Resolve<PageAViewModel>();
    }
}