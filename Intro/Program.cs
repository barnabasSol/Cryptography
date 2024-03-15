using Intro;

string message = "eduqdedv".Replace(" ", "").ToLower();
int key = 3;

Console.WriteLine(Caesar.Encrypt(message, key));

foreach (var item in Caesar.BruteForce(message))
{
    Console.WriteLine($"[{item}]");
}
