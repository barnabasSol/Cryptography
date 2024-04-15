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
            string joined = string.Concat(chunk);
            return Convert.ToUInt32(joined, 2).ToString("X");
        }

        public static uint ToLittleEndianHex(this uint value)
        {
            string x = Convert.ToString(value, 2).PadLeft(32, '0');
            var chunk = x.Chunk(8).Reverse().Select(s => new string(s));
            string joined = string.Concat(chunk);
            return Convert.ToUInt32(joined, 2);
        }

        public static string ToLittleEndian(this string value)
        {
            return string.Concat(value.Chunk(8).Reverse().Select(s => new string(s)));
        }

        public static string HashResult(this BufferProvider buf)
        {
            string hash = (
                buf.H0.ToLittleEndian()
                + buf.H1.ToLittleEndian()
                + buf.H2.ToLittleEndian()
                + buf.H3.ToLittleEndian()
                + buf.H4.ToLittleEndian()
            ).ToLower();
            return hash.Length == 39 ? 0 + hash : hash;
        }
    }
}
