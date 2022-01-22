namespace MagicMvvm.Helpers;

internal static class UriHelper
{
    private static readonly char[] _pathDelimiter = { '/' };

    public static Queue<string> GetUriSegments(Uri uri)
    {
        var segmentStack = new Queue<string>();

        if (!uri.IsAbsoluteUri)
        {
            uri = EnsureAbsolute(uri);
        }

        var segments = uri.PathAndQuery.Split(_pathDelimiter, StringSplitOptions.RemoveEmptyEntries);
        foreach (var segment in segments)
        {
            segmentStack.Enqueue(Uri.UnescapeDataString(segment));
        }

        return segmentStack;
    }

    public static string GetSegmentName(string segment)
    {
        return segment.Split('?')[0];
    }

    public static IParameters GetSegmentParameters(string segment)
    {
        var query = string.Empty;

        if (string.IsNullOrWhiteSpace(segment))
        {
            return new Parameters(query);
        }

        var indexOfQuery = segment.IndexOf('?');
        if (indexOfQuery > 0)
            query = segment.Substring(indexOfQuery);

        return new Parameters(query);
    }

    public static IParameters GetSegmentParameters(string uriSegment, IParameters parameters)
    {
        var navParameters = GetSegmentParameters(uriSegment);

        if (parameters != null)
        {
            foreach (var parameter in parameters)
            {
                navParameters.Add(parameter.Key, parameter.Value);
            }
        }

        return navParameters;
    }

    // public static IParameters GetSegmentDialogParameters(string segment)
    // {
    //     string query = string.Empty;
    //
    //     if (string.IsNullOrWhiteSpace(segment))
    //     {
    //         return new Parameters(query);
    //     }
    //
    //     var indexOfQuery = segment.IndexOf('?');
    //     if (indexOfQuery > 0)
    //         query = segment.Substring(indexOfQuery);
    //
    //     return new Parameters(query);
    // }
    //
    // public static IParameters GetSegmentParameters(string uriSegment, IParameters parameters)
    // {
    //     var dialogParameters = GetSegmentDialogParameters(uriSegment);
    //
    //     if (parameters != null)
    //     {
    //         foreach (var navigationParameter in parameters)
    //         {
    //             dialogParameters.Add(navigationParameter.Key, navigationParameter.Value);
    //         }
    //     }
    //
    //     return dialogParameters;
    // }

    public static Uri EnsureAbsolute(Uri uri)
    {
        if (uri.IsAbsoluteUri)
        {
            return uri;
        }

        if (!uri.OriginalString.StartsWith("/", StringComparison.Ordinal))
        {
            return new Uri("http://localhost/" + uri, UriKind.Absolute);
        }
        return new Uri("http://localhost" + uri, UriKind.Absolute);
    }

    public static Uri Parse(string uri)
    {
        if (uri == null) throw new ArgumentNullException(nameof(uri));

        if (uri.StartsWith("/", StringComparison.Ordinal))
        {
            return new Uri("http://localhost" + uri, UriKind.Absolute);
        }
        else
        {
            return new Uri(uri, UriKind.RelativeOrAbsolute);
        }
    }
}