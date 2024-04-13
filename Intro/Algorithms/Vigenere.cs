using System.Text;
using Intro.Algorithms.Contracts;
using Intro.Util;

namespace Intro.Algorithms;

public class Vigenere : IAlgoImpl<string>
{
    public string Encrypt(string plain_text, string key)
    {
        StringBuilder cypher = new();
        int k_index = 0;
        for (int i = 0; i < plain_text.Length; i++)
        {
            int cypher_index = Array.IndexOf(Alphabet.alphabet, key[k_index]);
            int plain_text_index = Array.IndexOf(Alphabet.alphabet, plain_text[i]);
            if (k_index == key.Length - 1)
                k_index = -1;
            int sum = cypher_index + plain_text_index;
            sum = sum > 25 ? sum - 26 : sum;
            cypher.Append(Alphabet.alphabet[sum]);
            k_index += 1;
        }
        return cypher.ToString();
    }

    public string Decrypt(string cipher, string key)
    {
        StringBuilder plain_text = new();
        int k_index = 0;
        for (int i = 0; i < cipher.Length; i++)
        {
            int dec_key_index = Array.IndexOf(Alphabet.alphabet, key[k_index]);
            int plain_text_index = Array.IndexOf(Alphabet.alphabet, cipher[i]);
            if (k_index == key.Length - 1)
                k_index = -1;
            int diff = plain_text_index - dec_key_index;
            diff = diff < 0 ? diff + 26 : diff;
            plain_text.Append(Alphabet.alphabet[diff]);
            k_index += 1;
        }
        return plain_text.ToString();
    }
}
