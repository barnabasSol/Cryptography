namespace Quiz;

public class Wef
{
    public static string Encrypt(string plain_text, string key)
    {
        string cypher = "";
        int x = 0;
        for (int i = 1; i <= plain_text.Length; i++)
        {
            cypher += plain_text[x] + key;
            x += 1;
        }
        return cypher;
    }

    public static string Decrypt(string cypher, string key)
    {
        int key_len = key.Length;
        string plain_text = "";
        for (int i = 0; i < cypher.Length; i++)
        {
            if (i % 2 == 0)
            {
                if (key.Length > 1){
                    
                }
                plain_text += cypher[i];
            }
        }
        return plain_text;
    }
}
