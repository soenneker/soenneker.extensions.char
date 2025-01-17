using BenchmarkDotNet.Attributes;

namespace Soenneker.Extensions.Char.Tests.Benchmarks;

[MemoryDiagnoser]
public class ToLowerInvariantBenchmark
{
    private char _c;

    [GlobalSetup]
    public void Setup()
    {
        _c = 'A'; // Uppercase character for testing
    }

    [Benchmark(Baseline = true)]
    public char ToLowerInvariantBuiltIn()
    {
        return char.ToLowerInvariant(_c);
    }

    [Benchmark]
    public char ToLowerInvariant()
    {
        return _c.ToLowerInvariant();
    }
}