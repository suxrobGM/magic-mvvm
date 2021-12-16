using System.Collections.Generic;
using System.Reflection;

namespace MagicMvvm.Blazor.Parameters;

internal interface IParameterResolver
{
    IEnumerable<PropertyInfo> ResolveParameters(Type memberType);
}