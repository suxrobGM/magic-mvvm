using System.Windows.Controls;
using DryIoc;
using AppNavigation.ViewModels.Pages;

namespace AppNavigation.Views.Pages
{
    /// <summary>
    /// Interaction logic for PageC.xaml
    /// </summary>
    public partial class PageC : Page
    {
        public PageC()
        {
            // Bind view model to DataContext
            DataContext = App.Container.Resolve<PageCViewModel>();
            InitializeComponent();
        }
    }
}
