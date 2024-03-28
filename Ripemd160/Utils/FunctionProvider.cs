namespace Ripemd160.Utils;

public class FunctionProvider
{
    public static uint Function(int index, uint bits1, uint bits2, uint bits3)
    {
        return index switch
        {
            _ when index < 16 => bits1 ^ bits2 ^ bits3,
            _ when index >= 16 && index < 32 => (bits1 & bits2) | (~bits1 & bits3),
            _ when index >= 32 && index < 48 => (bits1 | ~bits2) ^ bits3,
            _ when index >= 48 && index < 64 => (bits1 & bits3) | (bits2 & bits3),
            _ => bits1 ^ (bits2 | ~bits3),
        };
    }
}
