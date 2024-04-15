using Ripemd160.Utils.Extensions;

namespace Ripemd160.Utils;

public sealed class CompressionProvider
{
    public static void ComputeHash(char[] block, BufferProvider buf)
    {
        var _32bits_chunk = block.Chunk(32).ToArray();

        for (int i = 0; i < 80; i++)
        {
            buf.temp =
                (
                    buf.A
                    + FunctionProvider.Function(i, buf.B, buf.C, buf.D)
                    + Convert
                        .ToUInt32(new string(_32bits_chunk[MessageWordSelect.ForValues[i]]), 2)
                        .ToLittleEndianHex()
                    + Constant.ToAddForValueAt(i)
                ).RotateLeft(ShiftProvider.LeftRotateAmounts[i]) + buf.E;

            buf.A = buf.E;
            buf.E = buf.D;
            buf.D = buf.C.RotateLeft(10);
            buf.C = buf.B;
            buf.B = buf.temp;

            buf.temp =
                (
                    buf.APrime
                    + FunctionProvider.Function(79 - i, buf.BPrime, buf.CPrime, buf.DPrime)
                    + Convert
                        .ToUInt32(new string(_32bits_chunk[MessageWordSelect.ForPrimeValues[i]]), 2)
                        .ToLittleEndianHex()
                    + Constant.ToAddForPrimeValueAt(i)
                ).RotateLeft(ShiftProvider.PrimeLeftRotateAmounts[i]) + buf.EPrime;

            buf.APrime = buf.EPrime;
            buf.EPrime = buf.DPrime;
            buf.DPrime = buf.CPrime.RotateLeft(10);
            buf.CPrime = buf.BPrime;
            buf.BPrime = buf.temp;
        }

        uint temp = buf.H1 + buf.C + buf.DPrime;

        buf.H1 = buf.H2 + buf.D + buf.EPrime;
        buf.H2 = buf.H3 + buf.E + buf.APrime;
        buf.H3 = buf.H4 + buf.A + buf.BPrime;
        buf.H4 = buf.H0 + buf.B + buf.CPrime;
        buf.H0 = temp;
    }
}
