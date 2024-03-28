namespace Ripemd160.Utils;

public sealed class CompressionProvider
{
    public static void Compress(char[] block, BufferProvider buf)
    {
        var _16bits_word_chunk = block.Chunk(32).ToList();

        buf.Reset();

        for (int i = 0; i < 80; i++)
        {
            buf.TempHolder = (
                buf.A
                + FunctionProvider.Function(i, buf.B, buf.C, buf.D)
                + Convert.ToUInt32(
                    new string(_16bits_word_chunk[MessageWordSelect.ForValues[i]]),
                    2
                )
                + Constants.ToAddForValueAt(i)
                + buf.E
            ).RotateLeft(ShiftProvider.LeftRotateAmounts[i]);

            buf.A = buf.E;
            buf.E = buf.D;
            buf.D = buf.C.RotateLeft(10);
            buf.C = buf.B;
            buf.B = buf.TempHolder;

            buf.TempHolder = (
                buf.APrime
                + FunctionProvider.Function(79 - i, buf.BPrime, buf.CPrime, buf.DPrime)
                + Convert.ToUInt32(
                    new string(_16bits_word_chunk[MessageWordSelect.ForPrimeValues[i]]),
                    2
                )
                + Constants.ToAddForPrimeValueAt(i)
                + buf.EPrime
            ).RotateLeft(ShiftProvider.PrimeLeftRotateAmounts[i]);

            buf.APrime = buf.EPrime;
            buf.EPrime = buf.DPrime;
            buf.DPrime = buf.CPrime.RotateLeft(10);
            buf.CPrime = buf.BPrime;
            buf.BPrime = buf.TempHolder;
        }
    }
}
