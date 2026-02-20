using AwesomeAssertions;
using Xunit;

namespace Soenneker.Extensions.Char.Tests;

public class CharExtensionTests
{
    [Theory]
    [InlineData('\0', true)]
    [InlineData('A', true)]
    [InlineData('z', true)]
    [InlineData('0', true)]
    [InlineData('\x7F', true)]
    [InlineData('\x80', false)]
    [InlineData('é', false)]
    [InlineData('日', false)]
    public void IsAscii_ReturnsExpectedResult(char input, bool expected)
    {
        bool result = input.IsAscii();
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData('A', true)]
    [InlineData('Z', true)]
    [InlineData('M', true)]
    [InlineData('a', false)]
    [InlineData('z', false)]
    [InlineData('0', false)]
    [InlineData('@', false)]
    [InlineData('[', false)]
    [InlineData('Ä', false)]
    public void IsAsciiUpper_ReturnsExpectedResult(char input, bool expected)
    {
        bool result = input.IsAsciiUpper();
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData('a', true)]
    [InlineData('z', true)]
    [InlineData('m', true)]
    [InlineData('A', false)]
    [InlineData('Z', false)]
    [InlineData('0', false)]
    [InlineData('`', false)]
    [InlineData('{', false)]
    [InlineData('ä', false)]
    public void IsAsciiLower_ReturnsExpectedResult(char input, bool expected)
    {
        bool result = input.IsAsciiLower();
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData('A', true)]
    [InlineData('Z', true)]
    [InlineData('a', true)]
    [InlineData('z', true)]
    [InlineData('M', true)]
    [InlineData('m', true)]
    [InlineData('0', false)]
    [InlineData('9', false)]
    [InlineData('@', false)]
    [InlineData('[', false)]
    [InlineData('`', false)]
    [InlineData('{', false)]
    [InlineData('é', false)]
    public void IsAsciiLetter_ReturnsExpectedResult(char input, bool expected)
    {
        bool result = input.IsAsciiLetter();
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData('0', true)]
    [InlineData('9', true)]
    [InlineData('5', true)]
    [InlineData('/', false)]
    [InlineData(':', false)]
    [InlineData('A', false)]
    [InlineData('a', false)]
    [InlineData('٥', false)]
    public void IsAsciiDigit_ReturnsExpectedResult(char input, bool expected)
    {
        bool result = input.IsAsciiDigit();
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData('A', true)]
    [InlineData('Z', true)]
    [InlineData('a', true)]
    [InlineData('z', true)]
    [InlineData('0', true)]
    [InlineData('9', true)]
    [InlineData('_', false)]
    [InlineData('-', false)]
    [InlineData(' ', false)]
    [InlineData('@', false)]
    [InlineData('é', false)]
    public void IsAsciiAlphaNum_ReturnsExpectedResult(char input, bool expected)
    {
        bool result = input.IsAsciiAlphaNum();
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(' ', true)]
    [InlineData('\t', true)]
    [InlineData('\n', true)]
    [InlineData('\r', true)]
    [InlineData('\v', true)]
    [InlineData('\f', true)]
    [InlineData('A', false)]
    [InlineData('0', false)]
    [InlineData('\0', false)]
    [InlineData('\x1F', false)]
    [InlineData('\x7F', false)]
    [InlineData('\u00A0', false)]
    public void IsAsciiWhiteSpace_ReturnsExpectedResult(char input, bool expected)
    {
        bool result = input.IsAsciiWhiteSpace();
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData('a', 'A')]
    [InlineData('z', 'Z')]
    [InlineData('m', 'M')]
    [InlineData('A', 'A')]
    [InlineData('Z', 'Z')]
    [InlineData('0', '0')]
    [InlineData('_', '_')]
    [InlineData(' ', ' ')]
    [InlineData('é', 'é')]
    public void ToAsciiUpper_ReturnsExpectedResult(char input, char expected)
    {
        char result = input.ToAsciiUpper();
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData('A', 'a')]
    [InlineData('Z', 'z')]
    [InlineData('M', 'm')]
    [InlineData('a', 'a')]
    [InlineData('z', 'z')]
    [InlineData('0', '0')]
    [InlineData('_', '_')]
    [InlineData(' ', ' ')]
    [InlineData('É', 'É')]
    public void ToAsciiLower_ReturnsExpectedResult(char input, char expected)
    {
        char result = input.ToAsciiLower();
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData('a', 'A')]
    [InlineData('z', 'Z')]
    [InlineData('A', 'A')]
    [InlineData('Z', 'Z')]
    [InlineData('0', '0')]
    [InlineData('_', '_')]
    public void ToUpperInvariant_ConvertsToLowercaseLettersToUppercase(char input, char expected)
    {
        char result = input.ToUpperInvariant();
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData('a', 'a')]
    [InlineData('z', 'z')]
    [InlineData('A', 'a')]
    [InlineData('Z', 'z')]
    [InlineData('0', '0')]
    [InlineData('_', '_')]
    public void ToLowerInvariant_ConvertsToUppercaseLettersToLowercase(char input, char expected)
    {
        char result = input.ToLowerInvariant();
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData('A', true)]
    [InlineData('z', true)]
    [InlineData('0', true)]
    [InlineData('9', true)]
    [InlineData(' ', false)]
    [InlineData('_', false)]
    [InlineData('-', false)]
    [InlineData('é', true)]
    [InlineData('日', true)]
    [InlineData('٥', true)]
    public void IsLetterOrDigitFast_ReturnsExpectedResult(char input, bool expected)
    {
        bool result = input.IsLetterOrDigitFast();
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(' ', true)]
    [InlineData('\t', true)]
    [InlineData('\n', true)]
    [InlineData('\r', true)]
    [InlineData('A', false)]
    [InlineData('0', false)]
    [InlineData('\u00A0', true)]
    [InlineData('\u2003', true)]
    public void IsWhiteSpaceFast_ReturnsExpectedResult(char input, bool expected)
    {
        bool result = input.IsWhiteSpaceFast();
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData('0', true)]
    [InlineData('9', true)]
    [InlineData('5', true)]
    [InlineData('A', false)]
    [InlineData('a', false)]
    [InlineData(' ', false)]
    [InlineData('٥', true)]
    [InlineData('①', false)]
    public void IsDigit_ReturnsExpectedResult(char input, bool expected)
    {
        bool result = input.IsDigit();
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData('A', true)]
    [InlineData('z', true)]
    [InlineData('M', true)]
    [InlineData('0', false)]
    [InlineData('9', false)]
    [InlineData(' ', false)]
    [InlineData('_', false)]
    [InlineData('é', true)]
    [InlineData('日', true)]
    [InlineData('α', true)]
    public void IsLetter_ReturnsExpectedResult(char input, bool expected)
    {
        bool result = input.IsLetter();
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData('A', true)]
    [InlineData('Z', true)]
    [InlineData('M', true)]
    [InlineData('a', false)]
    [InlineData('z', false)]
    [InlineData('0', false)]
    [InlineData('É', true)]
    [InlineData('Ä', true)]
    [InlineData('é', false)]
    public void IsUpperFast_ReturnsExpectedResult(char input, bool expected)
    {
        bool result = input.IsUpperFast();
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData('a', true)]
    [InlineData('z', true)]
    [InlineData('m', true)]
    [InlineData('A', false)]
    [InlineData('Z', false)]
    [InlineData('0', false)]
    [InlineData('é', true)]
    [InlineData('ä', true)]
    [InlineData('É', false)]
    public void IsLowerFast_ReturnsExpectedResult(char input, bool expected)
    {
        bool result = input.IsLowerFast();
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(' ', true)]
    [InlineData('\t', true)]
    [InlineData('\n', true)]
    [InlineData('\r', true)]
    [InlineData('-', true)]
    [InlineData('.', true)]
    [InlineData('/', true)]
    [InlineData(':', true)]
    [InlineData(';', true)]
    [InlineData('\\', true)]
    [InlineData('_', true)]
    [InlineData('A', false)]
    [InlineData('a', false)]
    [InlineData('0', false)]
    [InlineData('@', false)]
    [InlineData('#', false)]
    [InlineData('!', false)]
    [InlineData('\x80', false)]
    [InlineData('é', false)]
    public void IsTokenSeparator_ReturnsExpectedResult(char input, bool expected)
    {
        bool result = input.IsTokenSeparator();
        result.Should().Be(expected);
    }

    [Fact]
    public void IsAscii_BoundaryValues_WorkCorrectly()
    {
        '\x00'.IsAscii().Should().BeTrue();
        '\x7F'.IsAscii().Should().BeTrue();
        '\x80'.IsAscii().Should().BeFalse();
        '\xFF'.IsAscii().Should().BeFalse();
    }

    [Fact]
    public void IsAsciiLetter_BoundaryValues_WorkCorrectly()
    {
        '@'.IsAsciiLetter().Should().BeFalse();
        'A'.IsAsciiLetter().Should().BeTrue();
        'Z'.IsAsciiLetter().Should().BeTrue();
        '['.IsAsciiLetter().Should().BeFalse();
        '`'.IsAsciiLetter().Should().BeFalse();
        'a'.IsAsciiLetter().Should().BeTrue();
        'z'.IsAsciiLetter().Should().BeTrue();
        '{'.IsAsciiLetter().Should().BeFalse();
    }

    [Fact]
    public void IsAsciiDigit_BoundaryValues_WorkCorrectly()
    {
        '/'.IsAsciiDigit().Should().BeFalse();
        '0'.IsAsciiDigit().Should().BeTrue();
        '9'.IsAsciiDigit().Should().BeTrue();
        ':'.IsAsciiDigit().Should().BeFalse();
    }

    [Fact]
    public void ToAsciiUpper_And_ToAsciiLower_AreInverses_ForAsciiLetters()
    {
        for (char c = 'a'; c <= 'z'; c++)
        {
            c.ToAsciiUpper().ToAsciiLower().Should().Be(c);
        }

        for (char c = 'A'; c <= 'Z'; c++)
        {
            c.ToAsciiLower().ToAsciiUpper().Should().Be(c);
        }
    }

    [Fact]
    public void FastMethods_MatchCharMethods_ForUnicodeCharacters()
    {
        char[] unicodeChars = { 'é', 'É', 'ñ', 'Ñ', '日', '本', 'α', 'Ω', '٥', '\u00A0' };

        foreach (char c in unicodeChars)
        {
            c.IsLetterOrDigitFast().Should().Be(char.IsLetterOrDigit(c));
            c.IsWhiteSpaceFast().Should().Be(char.IsWhiteSpace(c));
            c.IsDigit().Should().Be(char.IsDigit(c));
            c.IsLetter().Should().Be(char.IsLetter(c));
            c.IsUpperFast().Should().Be(char.IsUpper(c));
            c.IsLowerFast().Should().Be(char.IsLower(c));
        }
    }

    [Fact]
    public void IsTokenSeparator_AllDefinedSeparators_ReturnTrue()
    {
        char[] separators = { '\t', '\n', '\r', ' ', '-', '.', '/', ':', ';', '\\', '_' };

        foreach (char sep in separators)
        {
            sep.IsTokenSeparator().Should().BeTrue($"'{sep}' (U+{(int)sep:X4}) should be a token separator");
        }
    }

    [Fact]
    public void IsTokenSeparator_NonSeparators_ReturnFalse()
    {
        char[] nonSeparators = { 'A', 'z', '0', '9', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '+', '=' };

        foreach (char c in nonSeparators)
        {
            c.IsTokenSeparator().Should().BeFalse($"'{c}' should not be a token separator");
        }
    }
}
