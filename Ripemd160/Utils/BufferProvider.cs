namespace Ripemd160.Utils;

public sealed class BufferProvider
{
    public uint temp { get; set; }
    public uint H0 { get; set; } = 0x67452301;
    public uint H1 { get; set; } = 0xEFCDAB89;
    public uint H2 { get; set; } = 0x98BADCFE;
    public uint H3 { get; set; } = 0x10325476;
    public uint H4 { get; set; } = 0xC3D2E1F0;
    public uint A { get; set; }
    public uint B { get; set; }
    public uint C { get; set; }
    public uint D { get; set; }
    public uint E { get; set; }
    public uint APrime { get; set; }
    public uint BPrime { get; set; }
    public uint CPrime { get; set; }
    public uint DPrime { get; set; }
    public uint EPrime { get; set; }

    public void Set()
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
