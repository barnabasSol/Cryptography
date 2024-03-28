namespace Ripemd160.Utils;

public sealed class BufferProvider
{
    public uint TempHolder { get; set; }

    public static uint H0 { get; set; } = 0x67452301;
    public static uint H1 { get; set; } = 0xEFCDAB89;
    public static uint H2 { get; set; } = 0x98BADCFE;
    public static uint H3 { get; set; } = 0x10325476;
    public static uint H4 { get; set; } = 0xC3D2E1F0;

    public uint A { get; set; } = H0;
    public uint B { get; set; } = H1;
    public uint C { get; set; } = H2;
    public uint D { get; set; } = H3;
    public uint E { get; set; } = H4;

    public uint APrime { get; set; } = H0;
    public uint BPrime { get; set; } = H1;
    public uint CPrime { get; set; } = H2;
    public uint DPrime { get; set; } = H3;
    public uint EPrime { get; set; } = H4;

    public void Reset()
    {
        A = H0;
        B = H1;
        C = H2;
        D = H3;
        E = H4;

        APrime = H0;
        BPrime = H1;
        CPrime = H2;
        DPrime = H3;
        EPrime = H4;
    }

    public BufferProvider()
    {
        A = H0;
        B = H1;
        C = H2;
        D = H3;
        E = H4;

        APrime = H0;
        BPrime = H1;
        CPrime = H2;
        DPrime = H3;
        EPrime = H4;
    }
}
