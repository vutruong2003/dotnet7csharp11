using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet7Benchmark;

[MemoryDiagnoser]
public class RandomBenchmark
{
    [Benchmark]
    public double OldRandom()
    {
        var rand = new Random();
         
        return rand.NextDouble();
    }

    [Benchmark]
    public double NewRandom()
    {
        return Random.Shared.NextDouble();
    }
}
