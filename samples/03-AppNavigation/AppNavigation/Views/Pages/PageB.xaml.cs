using System.Windows.Controls;
using DryIoc;
using AppNavigation.ViewModels.Pages;

namespace AppNavigation.Views.Pages
{
    /// <summary>
    /// Interaction logic for PageB.xaml
    /// </summary>
    public partial class PageB : Page
    {
        public PageB()
        {
            // Bind view model to DataContext
            DataContext = App.Container.Resolve<PageBViewModel>();
            InitializeComponent();
        }
    }
}
