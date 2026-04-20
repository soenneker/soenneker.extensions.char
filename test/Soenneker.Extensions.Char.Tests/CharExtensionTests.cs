using AwesomeAssertions;

namespace Soenneker.Extensions.Char.Tests;

public class CharExtensionTests
{
    [Test]
    [Arguments('\0', true)]
    [Arguments('A', true)]
    [Arguments('z', true)]
    [Arguments('0', true)]
    [Arguments('\x7F', true)]
    [Arguments('\x80', false)]
    [Arguments('é', false)]
    [Arguments('日', false)]
    public void IsAscii_ReturnsExpectedResult(char input, bool expected)
    {
        bool result = input.IsAscii();
        result.Should().Be(expected);
    }

    [Test]
    [Arguments('A', true)]
    [Arguments('Z', true)]
    [Arguments('M', true)]
    [Arguments('a', false)]
    [Arguments('z', false)]
    [Arguments('0', false)]
    [Arguments('@', false)]
    [Arguments('[', false)]
    [Arguments('Ä', false)]
    public void IsAsciiUpper_ReturnsExpectedResult(char input, bool expected)
    {
        bool result = input.IsAsciiUpper();
        result.Should().Be(expected);
    }

    [Test]
    [Arguments('a', true)]
    [Arguments('z', true)]
    [Arguments('m', true)]
    [Arguments('A', false)]
    [Arguments('Z', false)]
    [Arguments('0', false)]
    [Arguments('`', false)]
    [Arguments('{', false)]
    [Arguments('ä', false)]
    public void IsAsciiLower_ReturnsExpectedResult(char input, bool expected)
    {
        bool result = input.IsAsciiLower();
        result.Should().Be(expected);
    }

    [Test]
    [Arguments('A', true)]
    [Arguments('Z', true)]
    [Arguments('a', true)]
    [Arguments('z', true)]
    [Arguments('M', true)]
    [Arguments('m', true)]
    [Arguments('0', false)]
    [Arguments('9', false)]
    [Arguments('@', false)]
    [Arguments('[', false)]
    [Arguments('`', false)]
    [Arguments('{', false)]
    [Arguments('é', false)]
    public void IsAsciiLetter_ReturnsExpectedResult(char input, bool expected)
    {
        bool result = input.IsAsciiLetter();
        result.Should().Be(expected);
    }

    [Test]
    [Arguments('0', true)]
    [Arguments('9', true)]
    [Arguments('5', true)]
    [Arguments('/', false)]
    [Arguments(':', false)]
    [Arguments('A', false)]
    [Arguments('a', false)]
    [Arguments('٥', false)]
    public void IsAsciiDigit_ReturnsExpectedResult(char input, bool expected)
    {
        bool result = input.IsAsciiDigit();
        result.Should().Be(expected);
    }

    [Test]
    [Arguments('A', true)]
    [Arguments('Z', true)]
    [Arguments('a', true)]
    [Arguments('z', true)]
    [Arguments('0', true)]
    [Arguments('9', true)]
    [Arguments('_', false)]
    [Arguments('-', false)]
    [Arguments(' ', false)]
    [Arguments('@', false)]
    [Arguments('é', false)]
    public void IsAsciiLetterOrDigit_ReturnsExpectedResult(char input, bool expected)
    {
        bool result = input.IsAsciiLetterOrDigit();
        result.Should().Be(expected);
    }

    [Test]
    [Arguments(' ', true)]
    [Arguments('\t', true)]
    [Arguments('\n', true)]
    [Arguments('\r', true)]
    [Arguments('\v', true)]
    [Arguments('\f', true)]
    [Arguments('A', false)]
    [Arguments('0', false)]
    [Arguments('\0', false)]
    [Arguments('\x1F', false)]
    [Arguments('\x7F', false)]
    [Arguments('\u00A0', false)]
    public void IsAsciiWhiteSpace_ReturnsExpectedResult(char input, bool expected)
    {
        bool result = input.IsAsciiWhiteSpace();
        result.Should().Be(expected);
    }

    [Test]
    [Arguments('a', 'A')]
    [Arguments('z', 'Z')]
    [Arguments('m', 'M')]
    [Arguments('A', 'A')]
    [Arguments('Z', 'Z')]
    [Arguments('0', '0')]
    [Arguments('_', '_')]
    [Arguments(' ', ' ')]
    [Arguments('é', 'é')]
    public void ToAsciiUpper_ReturnsExpectedResult(char input, char expected)
    {
        char result = input.ToAsciiUpper();
        result.Should().Be(expected);
    }

    [Test]
    [Arguments('A', 'a')]
    [Arguments('Z', 'z')]
    [Arguments('M', 'm')]
    [Arguments('a', 'a')]
    [Arguments('z', 'z')]
    [Arguments('0', '0')]
    [Arguments('_', '_')]
    [Arguments(' ', ' ')]
    [Arguments('É', 'É')]
    public void ToAsciiLower_ReturnsExpectedResult(char input, char expected)
    {
        char result = input.ToAsciiLower();
        result.Should().Be(expected);
    }

    [Test]
    [Arguments('a', 'A')]
    [Arguments('z', 'Z')]
    [Arguments('A', 'A')]
    [Arguments('Z', 'Z')]
    [Arguments('0', '0')]
    [Arguments('_', '_')]
    public void ToUpperInvariant_ConvertsToLowercaseLettersToUppercase(char input, char expected)
    {
        char result = input.ToUpperInvariant();
        result.Should().Be(expected);
    }

    [Test]
    [Arguments('a', 'a')]
    [Arguments('z', 'z')]
    [Arguments('A', 'a')]
    [Arguments('Z', 'z')]
    [Arguments('0', '0')]
    [Arguments('_', '_')]
    public void ToLowerInvariant_ConvertsToUppercaseLettersToLowercase(char input, char expected)
    {
        char result = input.ToLowerInvariant();
        result.Should().Be(expected);
    }

    [Test]
    [Arguments('A', true)]
    [Arguments('z', true)]
    [Arguments('0', true)]
    [Arguments('9', true)]
    [Arguments(' ', false)]
    [Arguments('_', false)]
    [Arguments('-', false)]
    [Arguments('é', true)]
    [Arguments('日', true)]
    [Arguments('٥', true)]
    public void IsLetterOrDigitFast_ReturnsExpectedResult(char input, bool expected)
    {
        bool result = input.IsLetterOrDigitFast();
        result.Should().Be(expected);
    }

    [Test]
    [Arguments(' ', true)]
    [Arguments('\t', true)]
    [Arguments('\n', true)]
    [Arguments('\r', true)]
    [Arguments('A', false)]
    [Arguments('0', false)]
    [Arguments('\u00A0', true)]
    [Arguments('\u2003', true)]
    public void IsWhiteSpaceFast_ReturnsExpectedResult(char input, bool expected)
    {
        bool result = input.IsWhiteSpaceFast();
        result.Should().Be(expected);
    }

    [Test]
    [Arguments('0', true)]
    [Arguments('9', true)]
    [Arguments('5', true)]
    [Arguments('A', false)]
    [Arguments('a', false)]
    [Arguments(' ', false)]
    [Arguments('٥', true)]
    [Arguments('①', false)]
    public void IsDigit_ReturnsExpectedResult(char input, bool expected)
    {
        bool result = input.IsDigitFast();
        result.Should().Be(expected);
    }

    [Test]
    [Arguments('A', true)]
    [Arguments('z', true)]
    [Arguments('M', true)]
    [Arguments('0', false)]
    [Arguments('9', false)]
    [Arguments(' ', false)]
    [Arguments('_', false)]
    [Arguments('é', true)]
    [Arguments('日', true)]
    [Arguments('α', true)]
    public void IsLetter_ReturnsExpectedResult(char input, bool expected)
    {
        bool result = input.IsLetterFast();
        result.Should().Be(expected);
    }

    [Test]
    [Arguments('A', true)]
    [Arguments('Z', true)]
    [Arguments('M', true)]
    [Arguments('a', false)]
    [Arguments('z', false)]
    [Arguments('0', false)]
    [Arguments('É', true)]
    [Arguments('Ä', true)]
    [Arguments('é', false)]
    public void IsUpperFast_ReturnsExpectedResult(char input, bool expected)
    {
        bool result = input.IsUpperFast();
        result.Should().Be(expected);
    }

    [Test]
    [Arguments('a', true)]
    [Arguments('z', true)]
    [Arguments('m', true)]
    [Arguments('A', false)]
    [Arguments('Z', false)]
    [Arguments('0', false)]
    [Arguments('é', true)]
    [Arguments('ä', true)]
    [Arguments('É', false)]
    public void IsLowerFast_ReturnsExpectedResult(char input, bool expected)
    {
        bool result = input.IsLowerFast();
        result.Should().Be(expected);
    }

    [Test]
    [Arguments(' ', true)]
    [Arguments('\t', true)]
    [Arguments('\n', true)]
    [Arguments('\r', true)]
    [Arguments('-', true)]
    [Arguments('.', true)]
    [Arguments('/', true)]
    [Arguments(':', true)]
    [Arguments(';', true)]
    [Arguments('\\', true)]
    [Arguments('_', true)]
    [Arguments('A', false)]
    [Arguments('a', false)]
    [Arguments('0', false)]
    [Arguments('@', false)]
    [Arguments('#', false)]
    [Arguments('!', false)]
    [Arguments('\x80', false)]
    [Arguments('é', false)]
    public void IsTokenSeparator_ReturnsExpectedResult(char input, bool expected)
    {
        bool result = input.IsTokenSeparator();
        result.Should().Be(expected);
    }

    [Test]
    public void IsAscii_BoundaryValues_WorkCorrectly()
    {
        '\x00'.IsAscii().Should().BeTrue();
        '\x7F'.IsAscii().Should().BeTrue();
        '\x80'.IsAscii().Should().BeFalse();
        '\xFF'.IsAscii().Should().BeFalse();
    }

    [Test]
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

    [Test]
    public void IsAsciiDigit_BoundaryValues_WorkCorrectly()
    {
        '/'.IsAsciiDigit().Should().BeFalse();
        '0'.IsAsciiDigit().Should().BeTrue();
        '9'.IsAsciiDigit().Should().BeTrue();
        ':'.IsAsciiDigit().Should().BeFalse();
    }

    [Test]
    public void ToAsciiUpper_And_ToAsciiLower_AreInverses_ForAsciiLetters()
    {
        for (var c = 'a'; c <= 'z'; c++)
        {
            c.ToAsciiUpper().ToAsciiLower().Should().Be(c);
        }

        for (var c = 'A'; c <= 'Z'; c++)
        {
            c.ToAsciiLower().ToAsciiUpper().Should().Be(c);
        }
    }

    [Test]
    public void FastMethods_MatchCharMethods_ForUnicodeCharacters()
    {
        char[] unicodeChars = { 'é', 'É', 'ñ', 'Ñ', '日', '本', 'α', 'Ω', '٥', '\u00A0' };

        foreach (char c in unicodeChars)
        {
            c.IsLetterOrDigitFast().Should().Be(char.IsLetterOrDigit(c));
            c.IsWhiteSpaceFast().Should().Be(char.IsWhiteSpace(c));
            c.IsDigitFast().Should().Be(char.IsDigit(c));
            c.IsLetterFast().Should().Be(char.IsLetter(c));
            c.IsUpperFast().Should().Be(char.IsUpper(c));
            c.IsLowerFast().Should().Be(char.IsLower(c));
        }
    }

    [Test]
    public void IsTokenSeparator_AllDefinedSeparators_ReturnTrue()
    {
        char[] separators = { '\t', '\n', '\r', ' ', '-', '.', '/', ':', ';', '\\', '_' };

        foreach (char sep in separators)
        {
            sep.IsTokenSeparator().Should().BeTrue($"'{sep}' (U+{(int)sep:X4}) should be a token separator");
        }
    }

    [Test]
    public void IsTokenSeparator_NonSeparators_ReturnFalse()
    {
        char[] nonSeparators = { 'A', 'z', '0', '9', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '+', '=' };

        foreach (char c in nonSeparators)
        {
            c.IsTokenSeparator().Should().BeFalse($"'{c}' should not be a token separator");
        }
    }
}