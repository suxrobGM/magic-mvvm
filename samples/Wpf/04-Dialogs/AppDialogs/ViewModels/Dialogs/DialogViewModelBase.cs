using System;
using MagicMvvm;
using MagicMvvm.Dialogs;


namespace AppDialogs.ViewModels.Dialogs
{
    /// <summary>
    /// Base view model for dialogs
    /// </summary>
    public abstract class DialogViewModelBase : ViewModelBase, IDialogAware
    {
        #region Methods

        protected virtual void CloseDialog(IDialogResult dialogResult = null)
        {
            RequestClose?.Invoke(dialogResult ?? new DialogResult());
        }

        #endregion

        #region Implementation of IDialogAware

        public string Title { get; protected set;}

        public event Action<IDialogResult> RequestClose;

        public virtual bool CanCloseDialog()
        {
            return true;
        }

        public virtual void OnDialogClosed()
        {

        }

        public virtual void OnDialogOpened(IDialogParameters parameters)
        {

        }

        #endregion
    }
}
