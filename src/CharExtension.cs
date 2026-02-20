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

    // ASCII 0..63
    private const ulong _tokenSepMaskLo =
        (1UL << 9) | // \t
        (1UL << 10) | // \n
        (1UL << 13) | // \r
        (1UL << 32) | // ' '
        (1UL << 45) | // '-'
        (1UL << 46) | // '.'
        (1UL << 47) | // '/'
        (1UL << 58) | // ':'
        (1UL << 59);  // ';'

    // ASCII 64..127 (bit index = code - 64)
    private const ulong _tokenSepMaskHi =
        (1UL << (92 - 64)) | // '\\' (28)
        (1UL << (95 - 64));  // '_'  (31)

    /// <summary>
    /// Determines whether the character is within the 7-bit ASCII range (U+0000 to U+007F).
    /// </summary>
    /// <param name="c">The character to evaluate.</param>
    /// <returns><see langword="true"/> if the character is ASCII; otherwise, <see langword="false"/>.</returns>
    [Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsAscii(this char c) => c <= 0x7F;

    /// <summary>
    /// Determines whether the character is an ASCII uppercase letter ('A' through 'Z').
    /// </summary>
    /// <param name="c">The character to evaluate.</param>
    /// <returns><see langword="true"/> if the character is an ASCII uppercase letter; otherwise, <see langword="false"/>.</returns>
    [Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsAsciiUpper(this char c) => (uint)(c - 'A') <= 25;

    /// <summary>
    /// Determines whether the character is an ASCII lowercase letter ('a' through 'z').
    /// </summary>
    /// <param name="c">The character to evaluate.</param>
    /// <returns><see langword="true"/> if the character is an ASCII lowercase letter; otherwise, <see langword="false"/>.</returns>
    [Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsAsciiLower(this char c) => (uint)(c - 'a') <= 25;

    /// <summary>
    /// Determines whether the character is an ASCII letter ('A'–'Z' or 'a'–'z').
    /// </summary>
    /// <param name="c">The character to evaluate.</param>
    /// <returns><see langword="true"/> if the character is an ASCII letter; otherwise, <see langword="false"/>.</returns>
    [Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsAsciiLetter(this char c) => (uint)((c | 0x20) - 'a') <= 25;

    /// <summary>
    /// Determines whether the character is an ASCII digit ('0' through '9').
    /// </summary>
    /// <param name="c">The character to evaluate.</param>
    /// <returns><see langword="true"/> if the character is an ASCII digit; otherwise, <see langword="false"/>.</returns>
    [Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsAsciiDigit(this char c) => (uint)(c - '0') <= 9;

    /// <summary>
    /// Determines whether the character is ASCII alphanumeric ('A'–'Z', 'a'–'z', or '0'–'9').
    /// </summary>
    /// <param name="c">The character to evaluate.</param>
    /// <returns><see langword="true"/> if the character is ASCII alphanumeric; otherwise, <see langword="false"/>.</returns>
    [Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsAsciiAlphaNum(this char c)
    {
        // digits first often wins for numeric-heavy inputs (IDs), but either is fine
        return (uint)(c - '0') <= 9 || (uint)((c | 0x20) - 'a') <= 25;
    }

    /// <summary>
    /// Determines whether the character is ASCII whitespace.
    /// This checks for: space (U+0020), tab (U+0009), LF (U+000A),
    /// VT (U+000B), FF (U+000C), and CR (U+000D).
    /// </summary>
    /// <param name="c">The character to evaluate.</param>
    /// <returns><see langword="true"/> if the character is one of the ASCII whitespace characters; otherwise, <see langword="false"/>.</returns>
    [Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsAsciiWhiteSpace(this char c)
    {
        if (c <= ' ')
            return c == ' ' || (uint)(c - '\t') <= '\r' - '\t'; // \t \n \v \f \r
        return false;
    }

    /// <summary>
    /// Converts an ASCII lowercase letter ('a'–'z') to its uppercase equivalent.
    /// Non-ASCII or non-lowercase characters are returned unchanged.
    /// </summary>
    /// <param name="c">The character to convert.</param>
    /// <returns>The uppercase ASCII equivalent if applicable; otherwise, the original character.</returns>
    [Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char ToAsciiUpper(this char c) => IsAsciiLower(c) ? (char)(c - _bitChange) : c;

    /// <summary>
    /// Converts an ASCII uppercase letter ('A'–'Z') to its lowercase equivalent.
    /// Non-ASCII or non-uppercase characters are returned unchanged.
    /// </summary>
    /// <param name="c">The character to convert.</param>
    /// <returns>The lowercase ASCII equivalent if applicable; otherwise, the original character.</returns>
    [Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char ToAsciiLower(this char c) => IsAsciiUpper(c) ? (char)(c + _bitChange) : c;

    /// <summary>
    /// Converts an ASCII lowercase character ('a'..'z') to uppercase ('A'..'Z').
    /// All other characters remain unchanged.
    /// </summary>
    /// <remarks>
    /// Despite the name, this method is ASCII-only and does not perform full Unicode casing.
    /// </remarks>
    /// <param name="c">The character to convert.</param>
    /// <returns>The uppercase ASCII equivalent if applicable; otherwise, the original character.</returns>
    [Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char ToUpperInvariant(this char c) => ToAsciiUpper(c);

    /// <summary>
    /// Converts an ASCII uppercase character ('A'..'Z') to lowercase ('a'..'z').
    /// All other characters remain unchanged.
    /// </summary>
    /// <remarks>
    /// Despite the name, this method is ASCII-only and does not perform full Unicode casing.
    /// </remarks>
    /// <param name="c">The character to convert.</param>
    /// <returns>The lowercase ASCII equivalent if applicable; otherwise, the original character.</returns>
    [Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char ToLowerInvariant(this char c) => ToAsciiLower(c);

    // -------------------------
    // Fast classification (ASCII + Unicode fallback)
    // -------------------------

    /// <summary>
    /// Determines whether the character is a letter or digit using a fast ASCII path,
    /// falling back to <see cref="char.IsLetterOrDigit(char)"/> for non-ASCII input.
    /// </summary>
    /// <param name="c">The character to evaluate.</param>
    /// <returns><see langword="true"/> if the character is a letter or digit; otherwise, <see langword="false"/>.</returns>
    [Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsLetterOrDigitFast(this char c)
    {
        uint uc = c;
        return uc <= 127 ? uc - '0' <= 9 || (uc | 0x20) - 'a' <= 25 : char.IsLetterOrDigit(c);
    }

    /// <summary>
    /// Determines whether the character is whitespace using a fast ASCII path
    /// (space, tab, LF, VT, FF, CR), falling back to <see cref="char.IsWhiteSpace(char)"/>
    /// for non-ASCII input.
    /// </summary>
    /// <param name="c">The character to evaluate.</param>
    /// <returns><see langword="true"/> if the character is whitespace; otherwise, <see langword="false"/>.</returns>
    [Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsWhiteSpaceFast(this char c)
    {
        uint uc = c;

        // ASCII whitespace: ' ' or 0x09..0x0D
        if (uc <= 32)
            return uc == 32 || (uc - 9) <= 4;

        if (uc <= 127)
            return false;

        return char.IsWhiteSpace(c);
    }

    /// <summary>
    /// Determines whether the character is a digit using a fast ASCII path,
    /// falling back to <see cref="char.IsDigit(char)"/> for non-ASCII input.
    /// </summary>
    /// <param name="c">The character to evaluate.</param>
    /// <returns><see langword="true"/> if the character is a digit; otherwise, <see langword="false"/>.</returns>
    [Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsDigit(this char c)
    {
        uint uc = c;
        return uc <= 127 ? uc - '0' <= 9 : char.IsDigit(c);
    }

    /// <summary>
    /// Determines whether the character is a letter using a fast ASCII path,
    /// falling back to <see cref="char.IsLetter(char)"/> for non-ASCII input.
    /// </summary>
    /// <param name="c">The character to evaluate.</param>
    /// <returns><see langword="true"/> if the character is a letter; otherwise, <see langword="false"/>.</returns>
    [Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsLetter(this char c) => c <= 127 ? IsAsciiLetter(c) : char.IsLetter(c);

    /// <summary>
    /// Determines whether the character is uppercase using a fast ASCII path,
    /// falling back to <see cref="char.IsUpper(char)"/> for non-ASCII input.
    /// </summary>
    /// <param name="c">The character to evaluate.</param>
    /// <returns><see langword="true"/> if the character is uppercase; otherwise, <see langword="false"/>.</returns>
    [Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsUpperFast(this char c) => c <= 127 ? IsAsciiUpper(c) : char.IsUpper(c);

    /// <summary>
    /// Determines whether the character is lowercase using a fast ASCII path,
    /// falling back to <see cref="char.IsLower(char)"/> for non-ASCII input.
    /// </summary>
    /// <param name="c">The character to evaluate.</param>
    /// <returns><see langword="true"/> if the character is lowercase; otherwise, <see langword="false"/>.</returns>
    [Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsLowerFast(this char c) => c <= 127 ? IsAsciiLower(c) : char.IsLower(c);

    /// <summary>
    /// Determines whether the character is considered a token separator.
    /// Separators include ASCII whitespace, underscore, hyphen, period, forward slash,
    /// backslash, colon, and semicolon.
    /// </summary>
    /// <param name="c">The character to evaluate.</param>
    /// <returns><see langword="true"/> if the character is a token separator; otherwise, <see langword="false"/>.</returns>
    [Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsTokenSeparator(this char c)
    {
        uint uc = c;

        if (uc > 127)
            return false;

        return uc < 64
            ? ((_tokenSepMaskLo >> (int)uc) & 1UL) != 0
            : ((_tokenSepMaskHi >> (int)(uc - 64)) & 1UL) != 0;
    }

    /// <summary>
    /// Determines whether the specified character is an ASCII newline character (line feed '\n' or carriage return
    /// '\r').
    /// </summary>
    /// <param name="c">The character to evaluate.</param>
    /// <returns>true if the character is '\n' or '\r'; otherwise, false.</returns>
    [Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsAsciiNewLine(this char c)
        => c is '\n' or '\r';
}