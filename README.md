[![](https://img.shields.io/nuget/v/soenneker.extensions.char.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.char/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.char/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.char/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.char.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.char/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.char/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.char/actions/workflows/codeql.yml)

# Soenneker.Extensions.Char

Allocation-free character classification and casing helpers with explicit ASCII-only operations and Unicode-aware fast paths.

## Installation

```bash
dotnet add package Soenneker.Extensions.Char
```

## ASCII-only operations

```csharp
using Soenneker.Extensions.Char;

bool ascii = 'A'.IsAscii();                    // true
bool letter = 'z'.IsAsciiLetter();             // true
bool digit = '٥'.IsAsciiDigit();                // false
bool identifierPart = '7'.IsAsciiLetterOrDigit(); // true

char upper = 'q'.ToAsciiUpper();               // 'Q'
char unchanged = 'é'.ToAsciiUpper();           // 'é'
```

The ASCII-only APIs never apply Unicode or culture rules:

- `IsAscii`, `IsAsciiUpper`, `IsAsciiLower`, `IsAsciiLetter`, `IsAsciiDigit`, `IsAsciiLetterOrDigit`
- `IsAsciiWhiteSpace` for space and U+0009 through U+000D
- `ToAsciiUpper` and `ToAsciiLower`, which leave non-ASCII characters unchanged
- `EqualsAsciiIgnoreCase(c, lower)`, where `lower` must be a lowercase ASCII letter (`'a'` through `'z'`)

`EqualsAsciiIgnoreCase` is intentionally specialized; it does not validate or normalize its second argument and is not a general Unicode case-insensitive comparison.

## Unicode-aware operations

```csharp
bool unicodeDigit = '٥'.IsDigitFast();       // true
bool unicodeLetter = '日'.IsLetterFast();    // true
bool unicodeSpace = '\u2003'.IsWhiteSpaceFast(); // true

char invariantUpper = 'é'.ToUpperInvariant(); // 'É'
```

`IsLetterOrDigitFast`, `IsDigitFast`, `IsLetterFast`, `IsUpperFast`, `IsLowerFast`, and `IsWhiteSpaceFast` use an ASCII branch and fall back to the matching `char` BCL method for non-ASCII input. Their classification semantics match those `char` methods; “Fast” describes the implementation path, not a narrower character set.

`ToUpperInvariant` and `ToLowerInvariant` use an ASCII branch and fall back to `char.ToUpperInvariant` / `char.ToLowerInvariant`. Like all `char` casing APIs, they return one UTF-16 code unit and cannot represent mappings that require multiple characters.

## Separators and newlines

`IsTokenSeparator()` recognizes exactly:

- ASCII whitespace: tab, line feed, vertical tab, form feed, carriage return, and space
- `_`, `-`, `.`, `/`, `\`, `:`, and `;`

All non-ASCII characters return `false` from `IsTokenSeparator()`.

`IsAsciiNewLine()` recognizes carriage return and line feed. `IsNewLineFast()` additionally recognizes next line (`U+0085`), line separator (`U+2028`), and paragraph separator (`U+2029`). Neither method treats a CRLF pair as one unit; call it for each character while parsing.

## UTF-16 boundary

A .NET `char` is a UTF-16 code unit, not necessarily a complete Unicode scalar value. Characters outside the Basic Multilingual Plane are represented by surrogate pairs, and these extensions see each surrogate separately. Use `System.Text.Rune` when classification must operate on full Unicode scalar values.
