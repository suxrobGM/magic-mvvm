using MagicMvvm.Parameters;
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
    private ILogger<ViewBase<T>> logger;

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
    protected T Model { get; set; }

    /// <summary>
    /// Injectable service provider.
    /// </summary>
    [Inject]
    public IServiceProvider ServiceProvider { get; set; }

    #region Internal methods

    private void SetBindingContext()
    {
        Model = ServiceProvider.GetRequiredService<T>();
        Model.PropertyChanged += DataContext_PropertyChanged;
        logger = ServiceProvider.GetService<ILogger<ViewBase<T>>>();
    }

    private void SetParameters()
    {
        if (Model is null)
            throw new InvalidOperationException("View model is not set");

        var parameterSetter = ServiceProvider.GetRequiredService<IParameterSetter>();
        parameterSetter.ResolveAndSet(this, Model);
    }

    private void DataContext_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        logger?.LogTrace("Raised property changed event {PropertyName}", e.PropertyName);
        StateHasChanged();
    }

    #endregion

    #region Lifecycle methods

    protected override void OnInitialized()
    {
        base.OnInitialized();
        SetBindingContext();
        SetParameters();
        Model?.OnInitialized();
    }

    protected override Task OnInitializedAsync()
    {
        return Model?.OnInitializedAsync() ?? Task.CompletedTask;
    }

    protected override void OnParametersSet()
    {
        Model?.OnParametersSet();
    }

    protected override Task OnParametersSetAsync()
    {
        return Model?.OnParametersSetAsync();
    }

    protected override void OnAfterRender(bool firstRender)
    {
        Model?.OnAfterRender(firstRender);
    }

    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        return Model?.OnAfterRenderAsync(firstRender) ?? Task.CompletedTask;
    }

    protected override bool ShouldRender()
    {
        return Model?.ShouldRender() ?? true;
    }

    #endregion

    #region Implementation of IDisposable

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposing)
            return;

        if (Model != null)
        {
            Model.PropertyChanged -= DataContext_PropertyChanged;
        }

        //logger?.LogTrace("Disposed view of the {ClassName}", typeof(T).Name);
    }

    ~ViewBase()
    {
        Dispose(false);
    }

    #endregion
}