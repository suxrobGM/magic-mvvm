

namespace MagicMvvm.Forms.AppModel;

/// <summary>
/// The default implementation of the <see cref="IKeyboardMapper"/>.
/// </summary>
public class KeyboardMapper : IKeyboardMapper
{
    /// <summary>
    /// Maps the <see cref="KeyboardType"/> to a <see cref="Keyboard"/>
    /// </summary>
    /// <param name="keyboardType">The Keyboard type.</param>
    /// <returns>The <see cref="Keyboard"/>.</returns>
    public virtual Keyboard Map(KeyboardType keyboardType)
    {
        switch (keyboardType)
        {
            case KeyboardType.Chat:
                return Keyboard.Chat;
            case KeyboardType.Default:
                return Keyboard.Default;
            case KeyboardType.Email:
                return Keyboard.Email;
            case KeyboardType.Numeric:
                return Keyboard.Numeric;
            case KeyboardType.Plain:
                return Keyboard.Plain;
            case KeyboardType.Telephone:
                return Keyboard.Telephone;
            case KeyboardType.Text:
                return Keyboard.Text;
            case KeyboardType.Url:
                return Keyboard.Url;
            default:
                throw new NotImplementedException(
                    $"The Keyboard Type value {keyboardType} is not supported. Please create and register an implementation of IKeyboardMapper to support this value.");
        }
    }
}