namespace Ripemd160.Utils;

public class BufferProvider
{
    private readonly uint[] HexBuffers =
    [
        0x67452301,
        0xEFCDAB89,
        0x98BADCFE,
        0x10325476,
        0xC3D2E1F0
    ];
    public string[] Values { get; set; } = new string[5];
    public string[] PrimeValues { get; set; } = new string[5];

    public BufferProvider()
    {
        for (int i = 0; i < HexBuffers.Length; i++)
        {
            Values[i] = Convert.ToString(HexBuffers[i], 2).PadLeft(32, '0');
            PrimeValues[i] = Convert.ToString(HexBuffers[i], 2).PadLeft(32, '0');
        }
    }
    
    public static string ToHex(string bit_buffer){
        return Convert.ToInt32(bit_buffer, 2).ToString("X");
    }
}
