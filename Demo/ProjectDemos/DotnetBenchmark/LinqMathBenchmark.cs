using BenchmarkDotNet.Attributes;

namespace DotnetBenchmark;

[SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net60, baseline: true)]
[SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net70, baseline: false)]
[MemoryDiagnoser]
public class LinqMathBenchmark
{
    [Params(10, 1000)]
    public int Size { get; set; }

    private List<int> _numbers;

    [GlobalSetup]
    public void Setup()
    {
        _numbers = Enumerable.Range(1, Size).Select(x => 1).ToList();
    }

    [Benchmark]
    public int Min()
    {
        return _numbers.Min();
    }

    [Benchmark]
    public int Max()
    {
        return _numbers.Max();
    }

    [Benchmark]
    public int Sum()
    {
        return _numbers.Sum();
    }

    [Benchmark]
    public double Average()
    {
        return _numbers.Average();
    }
}