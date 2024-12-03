using System.Diagnostics.Contracts;

namespace Soenneker.Extensions.Char;

/// <summary>
/// A collection of helpful char extension methods
/// </summary>
public static class CharExtension
{
    /// <summary>
    /// Converts the specified character to uppercase using the invariant culture.
    /// </summary>
    /// <param name="c">The character to convert.</param>
    /// <returns>The uppercase equivalent of the specified character, if the character is a lowercase letter; otherwise, the specified character.</returns>
    [Pure]
    public static char ToUpperInvariant(this char c)
    {
        if (c is >= 'a' and <= 'z')
        {
            return (char)(c & ~32); // Bitwise AND with complement of 32 sets the 6th bit, converting to uppercase
        }

        return c;
    }

    /// <summary>
    /// Converts the specified character to lowercase using the invariant culture.
    /// </summary>
    /// <param name="c">The character to convert.</param>
    /// <returns>The lowercase equivalent of the specified character, if the character is an uppercase letter; otherwise, the specified character.</returns>
    [Pure]
    public static char ToLowerInvariant(this char c)
    {
        if (c is >= 'A' and <= 'Z')
        {
            return (char)(c | 32); // Bitwise OR with 32 sets the 6th bit, converting to lowercase
        }

        return c;
    }
}