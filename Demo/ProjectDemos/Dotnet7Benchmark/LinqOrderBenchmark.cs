using BenchmarkDotNet.Attributes;

namespace Dotnet7Benchmark;

[MemoryDiagnoser]
public class LinqOrderBenchmark
{
    [Params(10000)]
    public int Length { get; set; }

    private double[] arr;

    [GlobalSetup]
    public void GlobalSetup()
    {
        arr = Enumerable
            .Range(0, Length)
            .Select(_ => Random.Shared.NextDouble())
            .ToArray();
    }

    [Benchmark]
    public double[] OrderBy() => arr.OrderBy(d => d).ToArray();

    [Benchmark]
    public double[] Order() => arr.Order().ToArray();
}
