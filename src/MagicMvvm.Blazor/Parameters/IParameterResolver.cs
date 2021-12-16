using System.Collections.Generic;
using System.Reflection;

namespace MagicMvvm.Parameters;

internal interface IParameterResolver
{
    IEnumerable<PropertyInfo> ResolveParameters(Type memberType);
}