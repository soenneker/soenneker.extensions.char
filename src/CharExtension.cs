using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace Soenneker.Extensions.Char;

/// <summary>
/// A collection of helpful char extension methods
/// </summary>
public static class CharExtension
{
    private const int _bitChange = 32;  // Difference between uppercase and lowercase

    /// <summary>
    /// Converts an ASCII lowercase character ('a'..'z') to uppercase ('A'..'Z').
    /// All other characters remain unchanged. Zero-allocation, minimal instructions.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char ToUpperInvariant(this char c)
    {
        return (uint)(c - 'a') <= 'z' - 'a' ? (char)(c - _bitChange) : c;
    }

    /// <summary>
    /// Converts the specified character to lowercase using the invariant culture.
    /// </summary>
    /// <param name="c">The character to convert.</param>
    /// <returns>The lowercase equivalent of the specified character, if the character is an uppercase letter; otherwise, the specified character.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char ToLowerInvariant(this char c)
    {
        return (uint)(c - 'A') <= 'Z' - 'A' ? (char)(c + _bitChange) : c;
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsLetterOrDigitFast(this char c)
    {
        if (c <= 127)
            return (uint)(c - '0') <= 9
                   || (uint)(c - 'A') <= 25
                   || (uint)(c - 'a') <= 25;

        return char.IsLetterOrDigit(c);
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsWhiteSpaceFast(this char c)
    {
        if (c <= '\r') // '\r' = 13
            return (uint)(c - 9) <= 4 || c == ' ';

        if (c == ' ')
            return true;

        if (c < 127)
            return false;

        return char.IsWhiteSpace(c);
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsDigit(this char c)
    {
        return c <= 127
            ? (uint)(c - '0') <= 9
            : char.IsDigit(c);
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsLetter(this char c)
    {
        return c <= 127
            ? (uint)(c - 'A') <= 25 || (uint)(c - 'a') <= 25
            : char.IsLetter(c);
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsUpperFast(this char c)
    {
        return c <= 127
            ? (uint)(c - 'A') <= 25
            : char.IsUpper(c);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsLowerFast(this char c)
    {
        return c <= 127
            ? (uint)(c - 'a') <= 25
            : char.IsLower(c);
    }
}