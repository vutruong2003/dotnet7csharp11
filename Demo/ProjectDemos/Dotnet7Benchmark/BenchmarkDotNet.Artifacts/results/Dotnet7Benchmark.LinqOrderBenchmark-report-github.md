``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22000.1335/21H2)
Intel Core i7-10750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.101
  [Host]     : .NET 7.0.1 (7.0.122.56804), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.1 (7.0.122.56804), X64 RyuJIT AVX2


```
|  Method | Length |     Mean |     Error |    StdDev |    Gen0 |    Gen1 | Allocated |
|-------- |------- |---------:|----------:|----------:|--------:|--------:|----------:|
| OrderBy |  10000 | 1.172 ms | 0.0120 ms | 0.0107 ms | 42.9688 |  1.9531 |  273.7 KB |
|   Order |  10000 | 1.197 ms | 0.0238 ms | 0.0292 ms | 31.2500 | 13.6719 | 195.56 KB |
