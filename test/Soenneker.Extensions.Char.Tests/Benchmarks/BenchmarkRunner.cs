using System.Threading.Tasks;
using BenchmarkDotNet.Reports;
using Soenneker.Benchmarking.Extensions.Summary;
using Soenneker.Tests.Benchmark;
using Xunit;

namespace Soenneker.Extensions.Char.Tests.Benchmarks;

public class BenchmarkRunner : BenchmarkTest
{
    public BenchmarkRunner(ITestOutputHelper outputHelper) : base(outputHelper)
    {
    }

    //[Fact]
    public async ValueTask IsDigit()
    {
        Summary summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<IsDigitBenchmark>(DefaultConf);

        await summary.OutputSummaryToLog(OutputHelper, CancellationToken);
    }

    // [Fact]
    public async ValueTask IsLetterOrDigit()
    {
        Summary summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<IsLetterOrDigitBenchmark>(DefaultConf);

        await summary.OutputSummaryToLog(OutputHelper, CancellationToken);
    }

    // [Fact]
    public async ValueTask IsWhiteSpace()
    {
        Summary summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<IsWhiteSpaceBenchmark>(DefaultConf);

        await summary.OutputSummaryToLog(OutputHelper, CancellationToken);
    }

    //  [Fact]
    public async ValueTask ToLowerInvariant()
    {
        Summary summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<ToLowerInvariantBenchmark>(DefaultConf);

        await summary.OutputSummaryToLog(OutputHelper, CancellationToken);
    }

    //  [Fact]
    public async ValueTask ToUpperInvariant()
    {
        Summary summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<ToUpperInvariantBenchmark>(DefaultConf);

        await summary.OutputSummaryToLog(OutputHelper, CancellationToken);
    }

    //  [Fact]
    public async ValueTask IsLower()
    {
        Summary summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<IsLowerBenchmark>(DefaultConf);

        await summary.OutputSummaryToLog(OutputHelper, CancellationToken);
    }

    //   [Fact]
    public async ValueTask IsUpper()
    {
        Summary summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<IsUpperBenchmark>(DefaultConf);

        await summary.OutputSummaryToLog(OutputHelper, CancellationToken);
    }
}