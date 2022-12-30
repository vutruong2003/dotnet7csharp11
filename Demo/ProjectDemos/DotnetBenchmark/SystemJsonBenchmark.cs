using BenchmarkDotNet.Attributes;
using System.Text.Json;

namespace DotnetBenchmark;

[SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net60, baseline: true)]
[SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net70, baseline: false)]
[MemoryDiagnoser]
public class SystemJsonBenchmark
{
    private JsonSerializerOptions _options = new JsonSerializerOptions();
    private readonly MyTestClass _instance = new MyTestClass();


    [Benchmark(Baseline = true)]
    public string ImplicitOptions() => JsonSerializer.Serialize(_instance);

    [Benchmark]
    public string WithOptions() => JsonSerializer.Serialize(_instance, _options);

    [Benchmark]
    public string WithNewOptions() => JsonSerializer.Serialize(_instance, new JsonSerializerOptions());

    private class MyTestClass
    {
        public int Value { get; set; }
    }
}