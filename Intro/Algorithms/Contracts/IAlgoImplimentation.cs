namespace Intro.Algorithms.Contracts;

public interface IAlgoImpl<T>
{
    string Encrypt(string plain_text, T key);
    string Decrypt(string cypher_text, T key);
}
