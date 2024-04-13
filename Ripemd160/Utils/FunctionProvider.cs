
namespace Ripemd160.Utils;

public class FunctionProvider
{
    public static uint Function(int index, uint x, uint y, uint z)
    {
        return index switch
        {
            _ when index < 16 => x ^ y ^ z,
            _ when index >= 16 && index < 32 => (x & y) | (~x & z),
            _ when index >= 32 && index < 48 => (x | ~y) ^ z,
            _ when index >= 48 && index < 64 => (x & z) | (y & ~z),
            _ => x ^ (y | ~z),
        };
    }
}
