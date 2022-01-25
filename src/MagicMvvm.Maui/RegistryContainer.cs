namespace MagicMvvm;

internal sealed class RegistryContainer
{
    public static readonly RegistryContainer Instance = new();

    private RegistryContainer()
    {
        Types = new List<Type>();
    }

    public List<Type> Types { get; }
}
