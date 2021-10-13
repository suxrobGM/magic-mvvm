using System.Windows.Controls;
using DryIoc;
using AppDialogs.ViewModels.Dialogs;

namespace AppDialogs.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for DialogB.xaml
    /// </summary>
    public partial class DialogB : UserControl
    {
        public DialogB()
        {
            DataContext = App.Container.Resolve<DialogAViewModel>();
            InitializeComponent();
        }
    }
}
