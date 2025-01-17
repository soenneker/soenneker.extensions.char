using BenchmarkDotNet.Attributes;

namespace Soenneker.Extensions.Char.Tests.Benchmarks;

[MemoryDiagnoser]
public class IsDigitBenchmark
{
    private char _c;

    [GlobalSetup]
    public void Setup()
    {
        _c = 'g';
    }

    [Benchmark(Baseline =true)]
    public bool IsDigitBuiltIn()
    {
        return char.IsDigit(_c);
    }

    [Benchmark]
    public bool IsDigit()
    {
        return _c.IsDigit();
    }
}