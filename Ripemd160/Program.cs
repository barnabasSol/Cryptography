using Ripemd160.Utils;

var buffers = new BufferProvider();

foreach (var item in buffers.PrimeValues)
{
    Console.WriteLine($"{item}   {item.Length}   {BufferProvider.ToHex(item)}");
}
