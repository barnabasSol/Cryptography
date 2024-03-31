using Ripemd160.Utils;
using Ripemd160.Utils.Extensions;

string message = "";
string input = InputProvider.InitialProcess(message);
var chunk = input.Chunk(512).ToList();
var buf = new BufferProvider();

foreach (var block in chunk)
{
    buf.Set();
    CompressionProvider.ComputeHash(block, buf);
}

buf.PrintHash();
