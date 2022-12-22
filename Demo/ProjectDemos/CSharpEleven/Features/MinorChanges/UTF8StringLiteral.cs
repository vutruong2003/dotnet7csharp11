using System.Text;

namespace CSharpEleven.MinorChanges;
internal class UTF8StringLiteral
{
    public static void Execute()
    {
        ReadOnlySpan<byte> text = "Vũ Truong"u8;

        ReadOnlySpan<byte> u16 = Encoding.Unicode.GetBytes("A");
        ReadOnlySpan<byte> u8 = "A"u8;

        Console.WriteLine($"{u16.Length}");
        Console.WriteLine($"{u8.Length}");
        Console.WriteLine($"{Encoding.Unicode.GetString(text)}");
    }
}
