using Ripemd160.Utils;
using Ripemd160.Utils.Extensions;

namespace Testing
{
    public class RipemdTests
    {
        [Fact]
        public void TestRIPEMD160Hash_EmptyString()
        {
            Assert.Equal("9c1185a5c5e9fc54612808977ee8f548b2258d31", ComputeHash(""));
        }

        [Fact]
        public void TestRIPEMD160Hash_SingleCharacter()
        {
            Assert.Equal("0bdc9d2d256b3ee9daae347be6f4dc835a467ffe", ComputeHash("a"));
        }

        [Fact]
        public void TestRIPEMD160Hash_ShortString()
        {
            Assert.Equal("8eb208f7e05d987a9b044a8e98c6b087f15a0bfc", ComputeHash("abc"));
        }

        [Fact]
        public void TestRIPEMD160Hash_LongString()
        {
            Assert.Equal("5d0689ef49d2fae572b881b123a85ffa21595f36", ComputeHash("message digest"));
        }

        [Fact]
        public void TestRIPEMD160Hash_AlphabetLowercase()
        {
            Assert.Equal(
                "f71c27109c692c1b56bbdceb5b9d2865b3708dbc",
                ComputeHash("abcdefghijklmnopqrstuvwxyz")
            );
        }

        [Fact]
        public void TestRIPEMD160Hash_MixedCaseString()
        {
            Assert.Equal(
                "12a053384a9c0c88e405a06c27dcf49ada62eb2b",
                ComputeHash("abcdbcdecdefdefgefghfghighijhijkijkljklmklmnlmnomnopnopq")
            );
        }

        [Fact]
        public void TestRIPEMD160Hash_AlphanumericString()
        {
            Assert.Equal(
                "b0e20b6e3116640286ed3a87a5713079b21f5189",
                ComputeHash("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789")
            );
        }

        [Fact]
        public void TestRIPEMD160Hash_OneMillionAs()
        {
            Assert.Equal(
                "52783243c1697bdbe16d37f97f68f08325dc1528",
                ComputeHash(new string('a', 1_000_000))
            );
        }

        [Fact]
        public void TestRIPEMD160Hash_8TmiesNumber()
        {
            Assert.Equal(
                "9b752e45573d4b39f4dbd3323cab82bf63326bfb",
                ComputeHash(string.Concat(Enumerable.Repeat("1234567890", 8)))
            );
        }

        private string ComputeHash(string message)
        {
            BufferProvider buf = new();
            string input = InputProvider.InitialProcess(message);
            var chunk = input.Chunk(512).ToList();

            foreach (var block in chunk)
            {
                buf.Set();
                CompressionProvider.ComputeHash(block, buf);
            }
            return buf.HashResult();
        }
    }
}
