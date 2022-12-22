using BenchmarkDotNet.Attributes;

namespace DotnetBenchmark;

[SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net60, baseline: true)]
[SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net70, baseline: false)]
[MemoryDiagnoser]
public class IOBenchmark
{
    private const string Write_Path = "readme.txt";
    private const string Read_Path = "readme.txt";
    private const string Write_Content = "Some content here";

    [Benchmark]
    public void WriteAllText() => File.WriteAllText(Write_Path, Write_Content);

    [Benchmark]
    public string ReadAllText() => File.ReadAllText(Read_Path);
}
