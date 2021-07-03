using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace MagicMvvm.Dialogs
{
    /// <summary>
    /// Implements <see cref="IDialogManager"/> to show modal or non-modal dialogs.
    /// </summary>
    /// <remarks>
    /// Register type as a singleton inside container.
    /// The dialog's ViewModel must implement IDialogAware.
    /// </remarks>
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
            ShowDialogInternal(dialogName, parameters, callback, false, windowName);
        }

        public void ShowDialog(string dialogName, IDialogParameters parameters, Action<IDialogResult> callback, string windowName)
        {
            ShowDialogInternal(dialogName, parameters, callback, true, windowName);
        }

        private void ShowDialogInternal(string dialogName, IDialogParameters parameters, Action<IDialogResult> callback, bool isModal, string windowName = null)
        {
            if (!_dialogsCollection.ContainsKey(dialogName))
                throw new InvalidOperationException($"The name of dialog {dialogName} was not registered inside registrar");

            parameters ??= new DialogParameters();

            var dialogWindow = CreateDialogWindow(windowName);
            ConfigureDialogWindowEvents(dialogWindow, callback, parameters);
            ConfigureDialogWindowContent(dialogName, dialogWindow);
            ShowDialogWindow(dialogWindow, isModal);
        }

        /// <summary>
        /// Shows the dialog host window.
        /// </summary>
        /// <param name="dialogHostWindow">The dialog host window to show.</param>
        /// <param name="isModal">If true; dialog is shown as a modal</param>
        protected virtual void ShowDialogWindow(IDialogHostWindow dialogHostWindow, bool isModal)
        {
            if (isModal)
                dialogHostWindow.ShowDialog();
            else
                dialogHostWindow.Show();
        }

        /// <summary>
        /// Create a new <see cref="IDialogHostWindow"/>.
        /// </summary>
        /// <param name="windowName">The unique name of dialog's hosting window.</param>
        /// <returns>The created <see cref="IDialogHostWindow"/>.</returns>
        protected virtual IDialogHostWindow CreateDialogWindow(string windowName)
        {
            if (string.IsNullOrEmpty(windowName))
            {
                return Activator.CreateInstance<DialogHostWindow>();
            }
            else if (_dialogHostWindowsCollection.TryGetValue(windowName, out var dialogHostViewType))
            {
                var dialogHostView = Activator.CreateInstance(dialogHostViewType);
                return dialogHostView as IDialogHostWindow;
            }

            return Activator.CreateInstance<DialogHostWindow>();
        }

        /// <summary>
        /// Configure <see cref="IDialogHostWindow"/> content.
        /// </summary>
        /// <param name="dialogName">The name of the dialog to show.</param>
        /// <param name="hostWindow">The hosting hostWindow.</param>
        protected virtual void ConfigureDialogWindowContent(string dialogName, IDialogHostWindow hostWindow)
        {
            var dialogViewType = _dialogsCollection[dialogName];
            var dialogView = Activator.CreateInstance(dialogViewType);

            if (!(dialogView is FrameworkElement dialogContent))
                throw new NullReferenceException("A dialog's content must be a FrameworkElement");


            if (!(dialogContent.DataContext is IDialogAware viewModel))
                throw new NullReferenceException("A dialog's ViewModel must implement the IDialogAware interface");

            ConfigureDialogWindowProperties(hostWindow, dialogContent, viewModel);
        }

        /// <summary>
        /// Configure <see cref="IDialogHostWindow"/> and <see cref="IDialogAware"/> events.
        /// </summary>
        /// <param name="hostWindow">The hosting window.</param>
        /// <param name="callback">The action to perform when the dialog is closed.</param>
        /// <param name="parameters">The parameters to pass to the dialog.</param>
        protected virtual void ConfigureDialogWindowEvents(IDialogHostWindow hostWindow, Action<IDialogResult> callback, IDialogParameters parameters)
        {
            void RequestCloseHandler(IDialogResult dialogResult)
            {
                hostWindow.Result = dialogResult;
                hostWindow.Close();
            }

            void LoadedHandler(object o, RoutedEventArgs e)
            {
                hostWindow.Loaded -= LoadedHandler;

                if (hostWindow.DataContext is IDialogAware viewModel)
                {
                    viewModel.RequestClose += RequestCloseHandler;
                    viewModel.OnDialogOpened(parameters);
                }
            }

            void ClosingHandler(object o, CancelEventArgs e)
            {
                if (hostWindow.DataContext is IDialogAware viewModel &&
                    !viewModel.CanCloseDialog())
                {
                    e.Cancel = true;
                }
            }

            void ClosedHandler(object o, EventArgs e)
            {
                hostWindow.Closed -= ClosedHandler;
                hostWindow.Closing -= ClosingHandler;

                if (hostWindow.DataContext is IDialogAware viewModel)
                {
                    viewModel.RequestClose -= RequestCloseHandler;
                    viewModel.OnDialogClosed();
                }

                hostWindow.Result ??= new DialogResult();
                callback?.Invoke(hostWindow.Result);

                hostWindow.DataContext = null;
                hostWindow.Content = null;
            }

            hostWindow.Loaded += LoadedHandler;
            hostWindow.Closing += ClosingHandler;
            hostWindow.Closed += ClosedHandler;
        }

        /// <summary>
        /// Configure <see cref="IDialogHostWindow"/> properties.
        /// </summary>
        /// <param name="hostWindow">The hosting window.</param>
        /// <param name="dialogContent">The dialog to show.</param>
        /// <param name="viewModel">The dialog's ViewModel.</param>
        protected virtual void ConfigureDialogWindowProperties(IDialogHostWindow hostWindow, FrameworkElement dialogContent, IDialogAware viewModel)
        {
            var windowStyle = DialogHost.GetWindowStyle(dialogContent);
            var matchParentSize = DialogHost.GetMatchParentSize(dialogContent);

            if (windowStyle != null)
                hostWindow.Style = windowStyle;

            hostWindow.Content = dialogContent;
            hostWindow.DataContext = viewModel;

            hostWindow.Owner ??= Application.Current?.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive);

            if (matchParentSize && hostWindow.Owner != null)
            {
                hostWindow.Width = hostWindow.Owner.Width;
                hostWindow.Height = hostWindow.Owner.Height;
            }
            else
            {
                hostWindow.Width = dialogContent.Width;
                hostWindow.Height = dialogContent.Height;
            }
        }
    }
}