``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22000.1335/21H2)
Intel Core i7-10750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


```
|  Method | Length |     Mean |    Error |   StdDev |   Gen0 |   Gen1 | Allocated |
|-------- |------- |---------:|---------:|---------:|-------:|-------:|----------:|
| OrderBy |   1000 | 84.70 μs | 0.576 μs | 0.450 μs | 4.3945 | 0.1221 |  27.61 KB |
|   Order |   1000 | 82.96 μs | 1.576 μs | 1.687 μs | 3.1738 |      - |  19.77 KB |
