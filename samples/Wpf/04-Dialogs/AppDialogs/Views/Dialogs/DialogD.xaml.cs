using System.Windows.Controls;
using DryIoc;
using AppDialogs.ViewModels.Dialogs;

namespace AppDialogs.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for DialogD.xaml
    /// </summary>
    public partial class DialogD : UserControl
    {
        public DialogD()
        {
            DataContext = App.Container.Resolve<DialogDViewModel>();
            InitializeComponent();
        }
    }
}
