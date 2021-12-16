using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MagicMvvm;

/// <summary>
/// Base class for razor components.
/// </summary>
/// <typeparam name="T">Type of the view model.</typeparam>
public abstract class ViewBase<T> : ComponentBase, IDisposable
    where T : ViewModelBase
{
    private ILogger<ViewBase<T>> _logger;

    protected ViewBase()
    {
    }

    protected ViewBase(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
    }
        
    /// <summary>
    /// Binding data context.
    /// </summary>
    public T DataContext { get; set; }

    /// <summary>
    /// Injectable service provider.
    /// </summary>
    [Inject]
    public IServiceProvider ServiceProvider { get; set; }
        
    private void ConfigureBindingContext()
    {
        DataContext = ServiceProvider.GetRequiredService<T>();
        DataContext.PropertyChanged += DataContext_PropertyChanged;
        _logger = ServiceProvider.GetService<ILogger<ViewBase<T>>>();
    }

    private void DataContext_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        _logger?.LogTrace("Raised property changed event {PropertyName}", e.PropertyName);
        StateHasChanged();
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        ConfigureBindingContext();
        DataContext?.OnInitialized();
    }

    protected override Task OnInitializedAsync()
    {
        return DataContext?.OnInitializedAsync() ?? Task.CompletedTask;
    }

    protected override void OnParametersSet()
    {
        DataContext?.OnParametersSet();
    }

    protected override Task OnParametersSetAsync()
    {
        return DataContext?.OnParametersSetAsync();
    }

    protected override void OnAfterRender(bool firstRender)
    {
        DataContext?.OnAfterRender(firstRender);
    }

    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        return DataContext?.OnAfterRenderAsync(firstRender) ?? Task.CompletedTask;
    }

    protected override bool ShouldRender()
    {
        return DataContext?.ShouldRender() ?? true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposing)
            return;

        if (DataContext != null)
        {
            DataContext.PropertyChanged -= DataContext_PropertyChanged;
        }

        _logger?.LogTrace("Disposed view of the {ClassName}", typeof(T).Name);
    }

    ~ViewBase()
    {
        Dispose(false);
    }
}