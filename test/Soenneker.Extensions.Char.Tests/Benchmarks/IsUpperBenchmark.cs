using BenchmarkDotNet.Attributes;

namespace Soenneker.Extensions.Char.Tests.Benchmarks;

[MemoryDiagnoser]
public class IsUpperBenchmark
{
    private char _upperChar;

    [GlobalSetup]
    public void Setup()
    {
        _upperChar = 'D';
    }

    [Benchmark(Baseline = true)]
    public bool IsUpperBuiltIn()
    {
        return char.IsUpper(_upperChar);
    }

    [Benchmark]
    public bool IsUpperFast()
    {
        return _upperChar.IsUpperFast();
    }
}