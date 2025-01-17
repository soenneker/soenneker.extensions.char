using System.Diagnostics.Contracts;
using System.Globalization;
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
        // 'a' = 97, 'z' = 122.
        // The unsigned range check is a known JIT-friendly pattern: (uint)(c - 'a') <= ('z' - 'a')
        if ((uint)(c - 'a') <= 'z' - 'a')
        {
            // Subtract 32 to flip lowercase a-z to uppercase A-Z
            // (Same as: c = (char)(c & 0xDF) for ASCII, but this is equally fast or faster.
            c = (char)(c - _bitChange);
        }
        return c;
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
        if ((uint)(c - 'A') <= 'Z' - 'A')
        {
            // Add 32 decimal to convert uppercase A-Z to lowercase a-z.
            c = (char)(c + _bitChange);
        }
        return c;
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsLetterOrDigitFast(this char c)
    {
        // Fast path for ASCII range
        if (c <= 127)
        {
            // Digits: '0'..'9'
            if ((uint)(c - '0') <= 9)
                return true;

            // Uppercase letters: 'A'..'Z'
            if ((uint)(c - 'A') <= 25)
                return true;

            // Lowercase letters: 'a'..'z'
            if ((uint)(c - 'a') <= 25)
                return true;

            // Not in the ASCII letter/digit ranges
            return false;
        }

        // Fallback for non-ASCII characters
        return char.IsLetterOrDigit(c);
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsWhiteSpaceFast(this char c)
    {
        // Fast path for ASCII <= 127
        // The most common whitespace chars within ASCII:
        //   ' ' (0x20), '\t'(0x09), '\n'(0x0A), '\v'(0x0B), '\f'(0x0C), '\r'(0x0D)
        // We'll do a tight check for c <= ' ' and see if it is one of the known ASCII spaces
        if (c <= ' ')
        {
            // The ' ' (space) check
            if (c == ' ')
                return true;

            // The [9..13] check covers '\t'(9), '\n'(10), '\v'(11), '\f'(12), '\r'(13)
            // Using an unsigned range check is typically efficient in .NET JIT:
            //   (uint)(c - 9) <= 4
            if ((uint)(c - 9) <= 4)
                return true;

            // Otherwise, it's below 9 or between 14..31 (not whitespace in ASCII)
            return false;
        }

        // If it's still within ASCII but > ' ' (32..127), then it's not whitespace
        if (c < 127)
            return false;

        // Fallback for full Unicode support
        return char.IsWhiteSpace(c);
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsDigit(this char c)
    {
        // Fast path for ASCII
        if (c <= 127)
        {
            // '0'..'9'
            // Using unsigned arithmetic for a tight boundary check:
            // (uint)(c - '0') <= 9 avoids extra branching.
            if ((uint)(c - '0') <= 9)
                return true;

            // Not an ASCII digit
            return false;
        }

        // Fallback for non-ASCII
        return char.IsDigit(c);
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsLetter(this char c)
    {
        // Fast path for ASCII
        if (c <= 127)
        {
            // 'A'..'Z'
            if ((uint)(c - 'A') <= 25)
                return true;

            // 'a'..'z'
            if ((uint)(c - 'a') <= 25)
                return true;

            // Not an ASCII letter
            return false;
        }

        // Fallback for non-ASCII
        return char.IsLetter(c);
    }


    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsUpperFast(this char c)
    {
        // Fast path for ASCII range
        if (c <= 127)
        {
            // 'A'..'Z'
            // Using unsigned arithmetic for a tight boundary check:
            // (uint)(c - 'A') <= 25 avoids extra branching.
            if ((uint)(c - 'A') <= 25)
                return true;

            return false;
        }

        // Fallback for non-ASCII range
        return char.IsUpper(c);
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsLowerFast(this char c)
    {
        // Fast path for ASCII
        if (c <= 127)
        {
            // 'a'..'z'
            if ((uint)(c - 'a') <= 25)
                return true;

            return false;
        }

        // Fallback for non-ASCII
        return char.IsLower(c);
    }
}