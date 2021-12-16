namespace MagicMvvm.Blazor.Parameters;

internal interface IParameterSetter
{
    void ResolveAndSet(ComponentBase component, ViewModelBase viewModel);
}