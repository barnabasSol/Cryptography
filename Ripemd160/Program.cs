using Ripemd160.Utils;

string message = "";
string input = InputProvider.InitialProcess(message);
var chunk = input.Chunk(512).ToList();
var buf = new BufferProvider();

Console.WriteLine(BufferProvider.H0.ToString("X"));
Console.WriteLine("---------------------");
foreach (var block in chunk)
{
    CompressionProvider.Compress(block, buf);

    var temp_holder = BufferProvider.H1 + buf.C + buf.DPrime;
    BufferProvider.H1 = BufferProvider.H2 + buf.D + buf.EPrime;
    BufferProvider.H2 = BufferProvider.H3 + buf.E + buf.APrime;
    BufferProvider.H3 = BufferProvider.H4 + buf.A + buf.BPrime;
    BufferProvider.H4 = BufferProvider.H0 + buf.B + buf.CPrime;
    BufferProvider.H0 = temp_holder;
}

static string ToLittleEndianHexString(uint value)
{
    byte[] bytes = BitConverter.GetBytes(value);
    if (!BitConverter.IsLittleEndian)
    {
        Array.Reverse(bytes);
    }
    return BitConverter.ToString(bytes).Replace("-", "");
}

// Console.WriteLine(BufferProvider.H0.ToString("X"));
// Console.WriteLine(BufferProvider.H1.ToString("X"));
// Console.WriteLine(BufferProvider.H2.ToString("X"));
// Console.WriteLine(BufferProvider.H3.ToString("X"));
// Console.WriteLine(BufferProvider.H4.ToString("X"));

Console.WriteLine(ToLittleEndianHexString(BufferProvider.H0));
Console.WriteLine(ToLittleEndianHexString(BufferProvider.H1));
Console.WriteLine(ToLittleEndianHexString(BufferProvider.H2));
Console.WriteLine(ToLittleEndianHexString(BufferProvider.H3));
Console.WriteLine(ToLittleEndianHexString(BufferProvider.H4));
