using System;
using System.Collections.Generic;

namespace MagicMvvm.Dialogs
{
    public class DialogManager : IDialogManager
    {
        private readonly IDictionary<string, Type> _dialogsCollection;
        private readonly IDictionary<string, Type> _dialogHostWindowsCollection;

        public DialogManager()
        {
            _dialogsCollection = new Dictionary<string, Type>();
            _dialogHostWindowsCollection = new Dictionary<string, Type>();
        }
        
        public IDialogManager RegisterDialog<TDialogView>(string dialogName)
        {
            if (string.IsNullOrEmpty(dialogName))
                throw new ArgumentNullException(nameof(dialogName));

            _dialogsCollection.Add(dialogName, typeof(TDialogView));
            return this;
        }

        public IDialogManager RegisterDialogHostWindow<TDialogHostWindow>(string windowName)
        {
            if (string.IsNullOrEmpty(windowName))
                throw new ArgumentNullException(nameof(windowName));

            _dialogHostWindowsCollection.Add(windowName, typeof(TDialogHostWindow));
            return this;
        }

        public void Show(string dialogName, IDialogParameters parameters, Action<IDialogResult> callback, string windowName)
        {
            throw new NotImplementedException();
        }

        public void ShowDialog(string dialogName, IDialogParameters parameters, Action<IDialogResult> callback, string windowName)
        {
            throw new NotImplementedException();
        }
    }
}