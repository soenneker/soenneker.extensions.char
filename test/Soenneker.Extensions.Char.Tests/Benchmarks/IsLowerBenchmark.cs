using BenchmarkDotNet.Attributes;

namespace Soenneker.Extensions.Char.Tests.Benchmarks;

[MemoryDiagnoser]
public class IsLowerBenchmark
{
    private char _lowerChar;

    [GlobalSetup]
    public void Setup()
    {
        _lowerChar = 'g';    // Lowercase ASCII
    }

    [Benchmark(Baseline =true)]
    public bool IsLowerBuiltIn()
    {
        return char.IsLower(_lowerChar);
    }

    [Benchmark]
    public bool IsLowerFast()
    {
        return _lowerChar.IsLowerFast();
    }
}