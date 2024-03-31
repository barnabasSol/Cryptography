using System.Text;
using Ripemd160.Utils.Extensions;

namespace Ripemd160.Utils;

public sealed class InputProvider
{
    public static string InitialProcess(string message)
    {
        var toasci = Encoding.ASCII.GetBytes(message);
        var tobits = toasci.Select(s => Convert.ToString(s, 2).PadLeft(8, '0'));
        string joined_bits = string.Join("", tobits);

        string original_bit_length_to_pad = Convert
            .ToString(joined_bits.Length, 2)
            .PadLeft(64, '0').ToLittleEndianBitString();

        joined_bits += "1";

        int total_length = 512;
        while (true)
        {
            if (total_length - 64 >= joined_bits.Length)
                break;
            total_length += 512;
        }

        total_length -= 64;
        joined_bits = joined_bits.PadRight(total_length, '0');
        joined_bits += original_bit_length_to_pad;

        return joined_bits;
    }
}
