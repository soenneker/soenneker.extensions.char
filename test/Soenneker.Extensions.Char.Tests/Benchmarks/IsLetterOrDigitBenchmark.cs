using BenchmarkDotNet.Attributes;

namespace Soenneker.Extensions.Char.Tests.Benchmarks;

[MemoryDiagnoser]
public class IsLetterOrDigitBenchmark
{
    private char _c;

    [GlobalSetup]
    public void Setup()
    {
        _c = '9'; // Digit character for testing
    }

    [Benchmark(Baseline = true)]
    public bool IsLetterOrDigitBuiltIn()
    {
        return char.IsLetterOrDigit(_c);
    }

    [Benchmark]
    public bool IsLetterOrDigit()
    {
        return _c.IsLetterOrDigitFast();
    }
}