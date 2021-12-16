using System.Collections.Generic;
using System.Reflection;

namespace MagicMvvm.Parameters;

internal class ParameterResolver : IParameterResolver
{
    public IEnumerable<PropertyInfo> ResolveParameters(Type memberType)
    {
        if (memberType == null) throw new ArgumentNullException(nameof(memberType));

        var componentProperties = memberType.GetProperties();

        var resolvedComponentProperties = new List<PropertyInfo>();
        foreach (var componentProperty in componentProperties)
        {
            // Skip if property has no public setter
            if (componentProperty.GetSetMethod() is null)
                continue;

            // If the property is marked as a parameter add it to the list
            var parameterAttribute = componentProperty.GetCustomAttribute<ParameterAttribute>();
            var cascadingParameterAttr = componentProperty.GetCustomAttribute<CascadingParameterAttribute>();
            
            if (parameterAttribute != null)
                resolvedComponentProperties.Add(componentProperty);

            if (cascadingParameterAttr != null)
                resolvedComponentProperties.Add(componentProperty);
        }

        return resolvedComponentProperties;
    }
}