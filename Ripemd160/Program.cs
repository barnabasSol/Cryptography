using Ripemd160.Utils;
using Ripemd160.Utils.Extensions;

internal class Program
{
    static void Main(string[] i)
    {
        string input = InputProvider.InitialProcess(i[0]);
        var chunk = input.Chunk(512);
        var buf = new BufferProvider();

        foreach (var block in chunk)
        {
            buf.Set();
            CompressionProvider.ComputeHash(block, buf);
        }
        Console.WriteLine(buf.HashResult(), ConsoleColor.Green);
    }
}
