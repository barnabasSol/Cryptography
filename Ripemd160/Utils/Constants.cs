namespace Ripemd160.Utils;

public sealed class Constants
{
    private static readonly uint[] ForValues =
    [
        0x00000000,
        0x5A827999,
        0x6ED9EBA1,
        0x8F1BBCDC,
        0xA953FD4E,
    ];

    private static readonly uint[] ForPrimeValues =
    [
        0x50A28BE6,
        0x5C4DD124,
        0x6D703EF3,
        0x7A6D76E9,
        0x00000000,
    ];
    public static uint ToAddForValueAt(int index)
    {
        return index switch
        {
            _ when index < 16 => ForValues[0],
            _ when index >= 16 && index < 32 => ForValues[1],
            _ when index >= 32 && index < 48 => ForValues[2],
            _ when index >= 48 && index < 64 => ForValues[3],
            _ => ForValues[4],
        };
    }

    public static uint ToAddForPrimeValueAt(int index)
    {
        return index switch
        {
            _ when index < 16 => ForPrimeValues[0],
            _ when index >= 16 && index < 32 => ForPrimeValues[1],
            _ when index >= 32 && index < 48 => ForPrimeValues[2],
            _ when index >= 48 && index < 64 => ForPrimeValues[3],
            _ => ForPrimeValues[4]
        };
    }
}
