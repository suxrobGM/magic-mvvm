namespace MagicMvvm.Dialogs;

/// <summary>
/// This class contains <see cref="IDialogHostWindow"/> attached properties.
/// </summary>
public class DialogHost
{
    /// <summary>
    /// Identifies the WindowStyle attached property.
    /// </summary>
    /// <remarks>
    /// This attached property is used to specify the style of a <see cref="IDialogHostWindow"/>.
    /// </remarks>
    public static readonly DependencyProperty WindowStyleProperty =
        DependencyProperty.RegisterAttached("WindowStyle", typeof(Style), typeof(DialogHost), new PropertyMetadata(null));

    public static Style GetWindowStyle(DependencyObject obj)
    {
        return (Style)obj.GetValue(WindowStyleProperty);
    }

    public static void SetWindowStyle(DependencyObject obj, Style value)
    {
        obj.SetValue(WindowStyleProperty, value);
    }


    /// <summary>
    /// Identifies the MatchParentSize attached property.
    /// </summary>
    /// <remarks>
    /// This attached property is used to indicate that change width and height of <see cref="IDialogHostWindow"/> to match parent size.
    /// By default, the width and height are sized to match the content size.
    /// </remarks>
    public static readonly DependencyProperty MatchParentSizeProperty = DependencyProperty.RegisterAttached(
        "MatchParentSize", typeof(bool), typeof(DialogHost), new PropertyMetadata(false));

    public static void SetMatchParentSize(DependencyObject element, bool value)
    {
        element.SetValue(MatchParentSizeProperty, value);
    }

    public static bool GetMatchParentSize(DependencyObject element)
    {
        return (bool) element.GetValue(MatchParentSizeProperty);
    }
}