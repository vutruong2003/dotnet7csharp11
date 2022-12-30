using BenchmarkDotNet.Attributes;
using System.Reflection;

namespace DotnetBenchmark;

[SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net60, baseline: true)]
[SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net70, baseline: false)]
[MemoryDiagnoser]
public class ReflectionBenchmark
{
    MethodInfo _method = typeof(MyTestClass)
        .GetMethod("TestMethod", BindingFlags.Public | BindingFlags.Static)!;

    [Params(1000)]
    public int Size { get; set; }

    [Benchmark]
    public object? InvokeMethodInfo()
    {
        object? result = null;

        for (int i = 0; i < Size; i++)
        {
            result = _method.Invoke(null, null);
        }

        return result;
    }

    private static class MyTestClass
    {
        public static int TestMethod() { return 0; }
    }
}

public class MyTestClass
{
    MethodInfo _method = typeof(MyTestClass)
        .GetMethod("TestMethod", BindingFlags.Public | BindingFlags.Static)!;

    public object? InvokeMethodInfo() => _method.Invoke(null, null);

    public static int TestMethod() { return 0; }
}