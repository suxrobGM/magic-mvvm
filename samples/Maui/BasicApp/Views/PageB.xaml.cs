using BasicApp.ViewModels;
using MagicMvvm;
using MagicMvvm.Attributes;

namespace BasicApp.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class PageB : ContentPage, IWiredView
{
	public PageB()
	{
		InitializeComponent();
	}
}