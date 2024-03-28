using System.Text;

namespace Ripemd160.Utils;

public sealed class InputProvider
{
    public static string InitialProcess(string message)
    {
        var toasci = Encoding.ASCII.GetBytes(message);
        var tobits = toasci.Select(s => Convert.ToString(s, 2).PadLeft(8, '0'));
        string joined_bits = string.Join("", tobits);

        joined_bits += "1";

        int required_0s_count = (448 - (joined_bits.Length % 512) + 512) % 512;

        joined_bits = joined_bits.PadRight(joined_bits.Length + required_0s_count, '0');

        string original_bit_length_to_pad = Convert
            .ToString(joined_bits.Length - 1, 2)
            .PadLeft(64, '0');

        joined_bits += original_bit_length_to_pad;

        return joined_bits;
    } 
}
