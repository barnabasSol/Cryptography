using Intro.Algorithms.Contracts;
using Intro.Util;

namespace Intro.Algorithms;

public class Caesar : IAlgoImpl<int>
{
    public string Decrypt(string cipher, int key)
    {
        string plain_text = "";
        for (int i = 0; i < cipher.Length; i++)
        {
            int index = Array.IndexOf(Alphabet.alphabet, cipher[i]) - key;
            if (index < 0)
                index += 26;
            plain_text += Alphabet.alphabet[index];
        }
        return plain_text;
    }

    public string Encrypt(string plain_text, int key)
    {
        string cipher = "";
        for (int i = 0; i < plain_text.Length; i++)
        {
            int index = Array.IndexOf(Alphabet.alphabet, plain_text[i]) + key;
            if (index > 26)
                index %= 26;
            cipher += Alphabet.alphabet[index];
        }
        return cipher;
    }
    public static string[] BruteForce(string cypher)
    {
        List<string> possible_results = [];
        string result = "";
        foreach (int key in Enumerable.Range(1, 26))
        {
            for (int j = 0; j < cypher.Length; j++)
            {
                int index = Array.IndexOf(Alphabet.alphabet, cypher[j]) - key;
                if (index < 0) index += 26;
                result += Alphabet.alphabet[index];
            }
            possible_results.Add(result);
            result = "";
        }
        return [.. possible_results];
    }

}
