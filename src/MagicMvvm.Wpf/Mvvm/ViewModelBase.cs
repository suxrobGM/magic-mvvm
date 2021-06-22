using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Microsoft.Extensions.Logging;

namespace MagicMvvm
{
    /// <summary>
    /// Base view model
    /// </summary>
    public abstract class ViewModelBase : BindableBase
    {
        private readonly ILogger<ViewModelBase> _logger;

        protected ViewModelBase(ILogger<ViewModelBase> logger = null)
        {
            _logger = logger;
        }

        /// <summary>
        /// Invoke <see cref="Action"/> in default UI thread.
        /// </summary>
        /// <param name="action"></param>
        protected void InvokeInUiThread(Action action)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    action();
                }
                catch (Exception ex)
                {
                    _logger?.LogError("Failed to execute action in UI thread, thrown exception: {Exception}", ex);
                }
            }, DispatcherPriority.Normal);
        }

        /// <summary>
        /// Invoke asynchronous <see cref="Action"/> in default UI thread.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        protected Task InvokeInUiThreadAsync(Func<CancellationToken, Task> action, CancellationToken token = default)
        {
            return Application.Current.Dispatcher.InvokeAsync(async () =>
            {
                try
                {
                    await action(token).ConfigureAwait(false);
                }
                catch(Exception ex)
                {
                    _logger?.LogError("Failed to execute async action in UI thread, thrown exception: {Exception}", ex);
                }
            }, DispatcherPriority.Normal, token).Task;
        }
    }
}