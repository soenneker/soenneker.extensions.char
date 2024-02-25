using FluentAssertions;
using Xunit;

namespace Soenneker.Extensions.Char.Tests;

public class CharExtensionTests
{
    [Theory]
    [InlineData('a', 'A')]
    [InlineData('z', 'Z')]
    [InlineData('A', 'A')]
    [InlineData('Z', 'Z')]
    [InlineData('0', '0')]
    [InlineData('_', '_')]
    public void ToUpperInvariant_ConvertsToLowercaseLettersToUppercase(char input, char expected)
    {
        // Arrange

        // Act
        var result = input.ToUpperInvariant();

        // Assert
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
        // Arrange

        // Act
        var result = input.ToLowerInvariant();

        // Assert
        result.Should().Be(expected);
    }
}
