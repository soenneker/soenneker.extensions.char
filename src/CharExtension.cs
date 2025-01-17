using System.Diagnostics.Contracts;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Soenneker.Extensions.Char;

/// <summary>
/// A collection of helpful char extension methods
/// </summary>
public static class CharExtension
{
    private static readonly byte[] _asciiWhitespaceLookup =
    [
        // 0x00 - 0x07
        0, 0, 0, 0, 0, 0, 0, 0,
        // 0x08 - 0x0F
        0, 1, 1, 1, 1, 1, 0, 0,
        // 0x10 - 0x17
        0, 0, 0, 0, 0, 0, 0, 0,
        // 0x18 - 0x1F
        0, 0, 0, 0, 0, 0, 0, 0,
        // 0x20 (space) to 0x27
        1, 0, 0, 0, 0, 0, 0, 0,
        // 0x28 - 0x2F
        0, 0, 0, 0, 0, 0, 0, 0,
        // 0x30 - 0x37
        0, 0, 0, 0, 0, 0, 0, 0,
        // 0x38 - 0x3F
        0, 0, 0, 0, 0, 0, 0, 0,
        // 0x40 - 0x47
        0, 0, 0, 0, 0, 0, 0, 0,
        // 0x48 - 0x4F
        0, 0, 0, 0, 0, 0, 0, 0,
        // 0x50 - 0x57
        0, 0, 0, 0, 0, 0, 0, 0,
        // 0x58 - 0x5F
        0, 0, 0, 0, 0, 0, 0, 0,
        // 0x60 - 0x67
        0, 0, 0, 0, 0, 0, 0, 0,
        // 0x68 - 0x6F
        0, 0, 0, 0, 0, 0, 0, 0,
        // 0x70 - 0x77
        0, 0, 0, 0, 0, 0, 0, 0,
        // 0x78 - 0x7F
        0, 0, 0, 0, 0, 0, 0, 0
    ];

    private static readonly bool[] _asciiLetterOrDigitLookup = CreateAsciiLookup();

    // TODO: Hard time to improve the speed of is letter os digit without caching
    private static bool[] CreateAsciiLookup()
    {
        var lookup = new bool[128];

        for (var c = (char)0; c < 128; c++)
        {
            lookup[c] = char.IsLetterOrDigit(c);
        }

        return lookup;
    }

    // Mask uppercase ASCII range (65–90) to lowercase (97–122)
    private const int _lowercaseMask = 0b0010_0000; // Binary mask to set the 6th bit
    private const int _letterRange = 26;

    // ASCII range constants
    private const int _upperCaseStart = 'A';
    private const int _lowerCaseStart = 'a';
    private const int _lowerCaseEnd = 'z';
    private const int _upperCaseEnd = 'Z';
    private const int _digitStart = '0';
    private const int _digitRange = 10;
    private const int _uppercaseMask = ~0b0010_0000; // Mask to clear the 6th bit for conversion

    /// <summary>
    /// Converts the specified character to uppercase using the invariant culture.
    /// </summary>
    /// <param name="c">The character to convert.</param>
    /// <returns>The uppercase equivalent of the specified character, if the character is a lowercase letter; otherwise, the specified character.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char ToUpperInvariant(this char c)
    {
        return (char)(c & ~((uint)(c - _lowerCaseStart) < _lowerCaseEnd - _lowerCaseStart + 1 ? 0 : _uppercaseMask));
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
        return (char)((c | ((c - _upperCaseStart) & ~(c - _upperCaseEnd - 1)) >> 31) & _lowercaseMask);
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsLetterOrDigitFast(this char c)
    {
        // Use precomputed table for ASCII characters
        if (c < 128)
            return _asciiLetterOrDigitLookup[c];

        // Fallback for non-ASCII characters
        return char.IsLetterOrDigit(c);
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsWhiteSpace(this char c)
    {
        // ASCII whitespace check
        return c < 128 && _asciiWhitespaceLookup[c] is not 0;
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsDigit(this char c)
    {
        // Branchless check for '0' to '9'
        return (uint)(c - _digitStart) < _digitRange;
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsLetter(this char c)
    {
        // Branchless range check for uppercase or lowercase letters
        return (uint)(c - _upperCaseStart) < _letterRange ||
               (uint)(c - _lowerCaseStart) < _letterRange;
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsUpperFast(this char c)
    {
        // Fast path for ASCII characters
        if ((uint)c - _upperCaseStart < _letterRange)
            return true;

        // Non-ASCII Unicode fallback
        return IsUnicodeUpperFast(c);
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsUnicodeUpperFast(this char c)
    {
        // Inline UnicodeCategory checking to reduce allocation
        UnicodeCategory category = CharUnicodeInfo.GetUnicodeCategory(c);
        return category is UnicodeCategory.UppercaseLetter;
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsLowerFast(this char c)
    {
        // ASCII fast path: Check if `c` is a lowercase letter ('a' to 'z')
        if ((uint)(c - _lowerCaseStart) < _letterRange)
            return true;

        // Non-ASCII Unicode fallback
        return IsUnicodeLowerFast(c);
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsUnicodeLowerFast(this char c)
    {
        // Inline UnicodeCategory checking to reduce allocation
        UnicodeCategory category = CharUnicodeInfo.GetUnicodeCategory(c);
        return category is UnicodeCategory.LowercaseLetter;
    }
}