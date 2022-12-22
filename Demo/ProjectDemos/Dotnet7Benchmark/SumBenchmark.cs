using BenchmarkDotNet.Attributes;

namespace Dotnet7Benchmark;

[MemoryDiagnoser]
public class SumBenchmark
{
    private List<int> numbers;
    private int[] numberArray;

    [Params(10000, 100000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        numbers = Enumerable.Range(1, Count).Select(x => 1).ToList();
        numberArray = numbers.ToArray();
    }

    [Benchmark(Baseline = true)]
    public long SumList()
    {
        var sum = 0;

        for (var i = 0; i < numbers.Count; i++)
        {
            sum += numbers[i];
        }

        return sum;
    }

    [Benchmark]
    public long SumListLinq()
    {
        return numbers.Sum();
    }

    [Benchmark]
    public long SumArray()
    {
        var sum = 0;

        for (var i = 0; i < numberArray.Length; i++)
        {
            sum += numberArray[i];
        }

        return sum;
    }

    [Benchmark]
    public long SumSpan()
    {
        return numberArray.SumNonOpt();
    }

    [Benchmark]
    public long SumSpanOpt()
    {
        return numberArray.SumOpt();
    }
}
