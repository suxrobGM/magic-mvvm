using DryIoc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinBasicApp.ViewModels;

namespace XamarinBasicApp.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class PageA : ContentPage
{
    public PageA()
    {
        InitializeComponent();
        BindingContext = App.Container.Resolve<PageAViewModel>();
    }
}