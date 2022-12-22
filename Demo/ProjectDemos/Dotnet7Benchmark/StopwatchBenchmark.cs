using BenchmarkDotNet.Attributes;
using System.Diagnostics;

namespace Dotnet7Benchmark;

[MemoryDiagnoser]
public class StopwatchBenchmark
{
    [Benchmark(Baseline = true)]
    public TimeSpan OldStopwatch()
    {
        Stopwatch sw = Stopwatch.StartNew();
        sw.Stop();

        return sw.Elapsed;
    }

    [Benchmark]
    public TimeSpan NewStopwatch()
    {
        long timestamp = Stopwatch.GetTimestamp();

        return Stopwatch.GetElapsedTime(timestamp);
    }
}
