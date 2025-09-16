using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace Soenneker.Extensions.Char;

/// <summary>
/// A collection of helpful <see cref="char"/> extension methods, optimized for fast ASCII checks
/// with safe Unicode fallbacks where needed.
/// </summary>
public static class CharExtension
{
    private const int _bitChange = 32; // Difference between uppercase and lowercase in ASCII

    // -------------------------
    // ASCII classification
    // -------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsAscii(this char c) => c <= 0x7F;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsAsciiUpper(this char c) => (uint)(c - 'A') <= 25;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsAsciiLower(this char c) => (uint)(c - 'a') <= 25;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsAsciiLetter(this char c) => IsAsciiUpper(c) || IsAsciiLower(c);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsAsciiDigit(this char c) => (uint)(c - '0') <= 9;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsAsciiAlphaNum(this char c) => IsAsciiLetter(c) || IsAsciiDigit(c);

    /// <summary>
    /// Checks for ASCII whitespace: space, tab, LF, VT, FF, CR.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsAsciiWhiteSpace(this char c)
    {
        if (c <= ' ')
            return c == ' ' || (uint)(c - '\t') <= ('\r' - '\t'); // \t \n \v \f \r
        return false;
    }

    // -------------------------
    // ASCII transforms
    // -------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char ToUpperAscii(this char c) => IsAsciiLower(c) ? (char)(c - _bitChange) : c;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char ToLowerAscii(this char c) => IsAsciiUpper(c) ? (char)(c + _bitChange) : c;

    // -------------------------
    // Back-compat names (ASCII-only!)
    // -------------------------

    /// <summary>
    /// Converts an ASCII lowercase character ('a'..'z') to uppercase ('A'..'Z').
    /// All other characters remain unchanged.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char ToUpperInvariant(this char c) => ToUpperAscii(c);

    /// <summary>
    /// Converts an ASCII uppercase character ('A'..'Z') to lowercase ('a'..'z').
    /// All other characters remain unchanged.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char ToLowerInvariant(this char c) => ToLowerAscii(c);

    // -------------------------
    // Fast classification (ASCII + Unicode fallback)
    // -------------------------

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsLetterOrDigitFast(this char c) => c <= 127 ? IsAsciiAlphaNum(c) : char.IsLetterOrDigit(c);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsWhiteSpaceFast(this char c)
    {
        if (IsAsciiWhiteSpace(c)) return true;
        if (c < 127) return false; // no other ASCII whitespace
        return char.IsWhiteSpace(c);
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsDigit(this char c) => c <= 127 ? IsAsciiDigit(c) : char.IsDigit(c);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsLetter(this char c) => c <= 127 ? IsAsciiLetter(c) : char.IsLetter(c);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsUpperFast(this char c) => c <= 127 ? IsAsciiUpper(c) : char.IsUpper(c);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsLowerFast(this char c) => c <= 127 ? IsAsciiLower(c) : char.IsLower(c);
}