namespace Intro;
public static class Caesar
{
    static readonly char[] alphabet = [
    'a', 'b', 'c', 'd', 'e',
    'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o',
    'p', 'q', 'r', 's', 't',
    'u', 'v', 'w', 'x', 'y',
    'z'
    ];
    public static string Encrypt(string plain_text, int key)
    {
        string cipher = "";
        for (int i = 0; i < plain_text.Length; i++)
        {
            int index = Array.IndexOf(alphabet, plain_text[i]) + key;
            if (index > 26)
                index %= 26;
            cipher += alphabet[index];
        }
        return cipher;
    }

    public static string Decrypt(string cipher, int key)
    {
        string plain_text = "";
        for (int i = 0; i < cipher.Length; i++)
        {
            int index = Array.IndexOf(alphabet, cipher[i]) - key;
            if (index < 0)
                index += 26;
            plain_text += alphabet[index];
        }
        return plain_text;
    }

    public static string[] BruteForce(string cypher)
    {
        List<string> possible_results = [];
        string result = "";
        for (int i = 1; i < 27; i++)
        {
            for (int j = 0; j < cypher.Length; j++)
            {
                int index = Array.IndexOf(alphabet, cypher[j]) - i;

                if (index < 0)
                    index += 26;

                result += alphabet[index];
            }
            possible_results.Add(result);
            result = "";
        }
        return [.. possible_results];
    }
}
