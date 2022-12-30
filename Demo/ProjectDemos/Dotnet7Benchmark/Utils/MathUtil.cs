using System.Numerics;

namespace Dotnet7Benchmark;

public static class MathUtil
{
    public static T SumNonOpt<T>(this T[] source) where T : struct, IAdditionOperators<T, T, T>
    {
        if (source is null || source.Any() == false)
            return default;

        var sum = source[0];
        ReadOnlySpan<T> span = source;

        for (var i = 1; i < span.Length; i++)
        {
            sum += span[i];
        }

        return sum;
    }
    public static T SumOpt<T>(this T[] source) where T : struct, IAdditionOperators<T, T, T>
    {
        if (Vector.IsHardwareAccelerated)
        {
            ReadOnlySpan<T> span = source;

            var sums = new Vector<T>(span);
            var index = Vector<T>.Count;

            while (index + Vector<T>.Count < span.Length - 1)
            {
                sums = Vector.Add<T>(sums, new Vector<T>(span.Slice(index)));
                index += Vector<T>.Count;
            }

            var sum = sums[0];
            for (int i = 1; i < Vector<T>.Count; i++)
            {
                sum += sums[i];
            }

            for (int i = index; (uint)i < (uint)span.Length; i++)
            {
                sum += span[i];
            }

            return sum;
        }

        return source.SumNonOpt();
    }
}