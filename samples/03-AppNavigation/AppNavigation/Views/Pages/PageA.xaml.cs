using System.Windows.Controls;
using DryIoc;
using AppNavigation.ViewModels.Pages;

namespace AppNavigation.Views.Pages
{
    /// <summary>
    /// Interaction logic for PageA.xaml
    /// </summary>
    public partial class PageA : Page
    {
        public PageA()
        {
            // Bind view model to DataContext
            DataContext = App.Container.Resolve<PageAViewModel>();
            InitializeComponent();
        }
    }
}
