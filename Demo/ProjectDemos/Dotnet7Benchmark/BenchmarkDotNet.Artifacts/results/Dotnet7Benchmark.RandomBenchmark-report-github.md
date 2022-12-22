``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22000.1335/21H2)
Intel Core i7-10750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


```
|    Method |       Mean |     Error |    StdDev |   Gen0 | Allocated |
|---------- |-----------:|----------:|----------:|-------:|----------:|
| OldRandom | 118.812 ns | 2.3518 ns | 4.9608 ns | 0.0114 |      72 B |
| NewRandom |   5.984 ns | 0.1464 ns | 0.2280 ns |      - |         - |
