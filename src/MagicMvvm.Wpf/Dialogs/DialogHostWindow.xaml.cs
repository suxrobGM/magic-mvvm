using System.Windows;

namespace MagicMvvm.Dialogs
{
    /// <summary>
    /// Default dialog host.
    /// </summary>
    public partial class DialogHostWindow : Window, IDialogHostWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DialogHostWindow"/> class.
        /// </summary>
        public DialogHostWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The <see cref="IDialogResult"/> of the dialog.
        /// </summary>
        public IDialogResult Result { get; set; }
    }
}
