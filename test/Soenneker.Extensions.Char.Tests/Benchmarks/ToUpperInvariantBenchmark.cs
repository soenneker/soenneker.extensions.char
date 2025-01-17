using BenchmarkDotNet.Attributes;

namespace Soenneker.Extensions.Char.Tests.Benchmarks;

[MemoryDiagnoser]
public class ToUpperInvariantBenchmark
{
    private char _c;

    [GlobalSetup]
    public void Setup()
    {
        _c = 'a'; // Lowercase character for testing
    }

    [Benchmark(Baseline = true)]
    public char ToUpperInvariantBuiltIn()
    {
        return char.ToUpperInvariant(_c);
    }

    [Benchmark]
    public char ToUpperInvariant()
    {
        return _c.ToUpperInvariant();
    }
}