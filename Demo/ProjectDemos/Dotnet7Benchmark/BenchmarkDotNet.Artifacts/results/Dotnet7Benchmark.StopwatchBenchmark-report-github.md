``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22000.1335/21H2)
Intel Core i7-10750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


```
|       Method |     Mean |    Error |   StdDev | Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------- |---------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| OldStopwatch | 34.54 ns | 0.721 ns | 1.599 ns |  1.00 |    0.00 | 0.0063 |      40 B |        1.00 |
| NewStopwatch | 27.38 ns | 0.571 ns | 0.762 ns |  0.78 |    0.04 |      - |         - |        0.00 |
