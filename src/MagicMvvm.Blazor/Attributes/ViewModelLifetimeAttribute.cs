namespace MagicMvvm;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
public sealed class ViewModelLifetimeAttribute : Attribute
{
    public ViewModelLifetimeAttribute(ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
    {
        ServiceLifetime = serviceLifetime;
    }

    public ServiceLifetime ServiceLifetime { get; }
}

public enum ServiceLifetime
{
    Scoped,
    Transient,
    Singleton
}
