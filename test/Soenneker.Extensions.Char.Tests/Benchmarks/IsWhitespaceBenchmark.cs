using BenchmarkDotNet.Attributes;

namespace Soenneker.Extensions.Char.Tests.Benchmarks;

[MemoryDiagnoser]
public class IsWhiteSpaceBenchmark
{
    private char _c;

    [GlobalSetup]
    public void Setup()
    {
        _c = ' '; // Setup a whitespace character
    }

    [Benchmark(Baseline = true)]
    public bool IsWhiteSpaceBuiltIn()
    {
        return char.IsWhiteSpace(_c); // Using the built-in .NET method
    }

    [Benchmark]
    public bool IsWhiteSpace()
    {
        return _c.IsWhiteSpaceFast();
    }
}