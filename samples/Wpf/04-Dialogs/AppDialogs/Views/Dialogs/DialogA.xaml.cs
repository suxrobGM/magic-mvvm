using System.Windows.Controls;
using DryIoc;
using AppDialogs.ViewModels.Dialogs;

namespace AppDialogs.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for DialogA.xaml
    /// </summary>
    public partial class DialogA : UserControl
    {
        public DialogA()
        {
            DataContext = App.Container.Resolve<DialogAViewModel>();
            InitializeComponent();
        }
    }
}
