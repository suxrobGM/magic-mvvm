namespace MagicMvvm.Parameters;

internal interface IParameterCache
{
    ParameterInfo Get(Type type);
    void Set(Type type, ParameterInfo info);
}