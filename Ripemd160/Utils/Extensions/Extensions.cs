namespace Ripemd160.Utils.Extensions
{
    public static class Extensions
    {
        public static uint RotateLeft(this uint value, int shift)
        {
            return value << shift | value >> 32 - shift;
        }

        public static string ToLittleEndian(this uint value)
        {
            string x = Convert.ToString(value, 2).PadLeft(32, '0');
            var chunk = x.Chunk(8).Reverse().Select(s => new string(s));
            string joined = string.Join("", chunk);
            return Convert.ToUInt32(joined, 2).ToString("X");
        }

        public static uint ToLittleEndianHex(this uint value)
        {
            string x = Convert.ToString(value, 2).PadLeft(32, '0');
            var chunk = x.Chunk(8).Reverse().Select(s => new string(s));
            string joined = string.Join("", chunk);
            return Convert.ToUInt32(joined, 2);
        }

        public static string ToLittleEndian(this string value)
        {
            return string.Join("", value.Chunk(8).Reverse().Select(s => new string(s)));
        }

        public static void PrintHash(this BufferProvider buf)
        {
            string h0 = BufferProvider.H0.ToLittleEndian();
            string h1 = BufferProvider.H1.ToLittleEndian();
            string h2 = BufferProvider.H2.ToLittleEndian();
            string h3 = BufferProvider.H3.ToLittleEndian();
            string h4 = BufferProvider.H4.ToLittleEndian();

            Console.WriteLine((h0 + h1 + h2 + h3 + h4).ToLower());
        }
    }
}
