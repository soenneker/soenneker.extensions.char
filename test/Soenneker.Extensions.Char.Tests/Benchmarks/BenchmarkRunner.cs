using System.Threading;
using System.Threading.Tasks;
using BenchmarkDotNet.Reports;
using Soenneker.Benchmarking.Extensions.Summary;
using Soenneker.Tests.Benchmark;

namespace Soenneker.Extensions.Char.Tests.Benchmarks;

public class BenchmarkRunner : BenchmarkTest
{
    public BenchmarkRunner() : base()
    {
    }

    //[Test]
    public async ValueTask IsDigit(CancellationToken cancellationToken)
    {
        Summary summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<IsDigitBenchmark>(DefaultConf);

        await summary.OutputSummaryToLog(cancellationToken);
    }

    // [Test]
    public async ValueTask IsLetterOrDigit(CancellationToken cancellationToken)
    {
        Summary summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<IsLetterOrDigitBenchmark>(DefaultConf);

        await summary.OutputSummaryToLog(cancellationToken);
    }

    // [Test]
    public async ValueTask IsWhiteSpace(CancellationToken cancellationToken)
    {
        Summary summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<IsWhiteSpaceBenchmark>(DefaultConf);

        await summary.OutputSummaryToLog(cancellationToken);
    }

    //  [Test]
    public async ValueTask ToLowerInvariant(CancellationToken cancellationToken)
    {
        Summary summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<ToLowerInvariantBenchmark>(DefaultConf);

        await summary.OutputSummaryToLog(cancellationToken);
    }

    //  [Test]
    public async ValueTask ToUpperInvariant(CancellationToken cancellationToken)
    {
        Summary summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<ToUpperInvariantBenchmark>(DefaultConf);

        await summary.OutputSummaryToLog(cancellationToken);
    }

    //  [Test]
    public async ValueTask IsLower(CancellationToken cancellationToken)
    {
        Summary summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<IsLowerBenchmark>(DefaultConf);

        await summary.OutputSummaryToLog(cancellationToken);
    }

    //   [Test]
    public async ValueTask IsUpper(CancellationToken cancellationToken)
    {
        Summary summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<IsUpperBenchmark>(DefaultConf);

        await summary.OutputSummaryToLog(cancellationToken);
    }
}