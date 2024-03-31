namespace Ripemd160.Utils.Extensions
{
    public static class UIntExtensions
    {
        public static uint RotateLeft(this uint value, int shift)
        {
            return value << shift | value >> 32 - shift;
        }

        public static string ToLittleEndianHexString(this uint value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }
            return BitConverter.ToString(bytes).Replace("-", "");
        }

        public static string ToLittleEndianBitString(this string value)
        {
            return string.Join("", value.Chunk(8).Reverse().Select(s => new string(s)));
        }

        public static void PrintHash(this BufferProvider buf)
        {
            string h0 = BufferProvider.H0.ToLittleEndianHexString();
            string h1 = BufferProvider.H1.ToLittleEndianHexString();
            string h2 = BufferProvider.H2.ToLittleEndianHexString();
            string h3 = BufferProvider.H3.ToLittleEndianHexString();
            string h4 = BufferProvider.H4.ToLittleEndianHexString();
            Console.WriteLine((h0 + h1 + h2 + h3 + h4).ToLower());
        }
    }
}
