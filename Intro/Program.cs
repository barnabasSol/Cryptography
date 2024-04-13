using Intro.Algorithms;
using Intro.Util;

string message = "miscelaneous".Replace(" ", "").ToLower();

int key = 3;
string v_key = "key";

PrintResult.Print(
    title: "Caesar",
    color: ConsoleColor.DarkMagenta,
    message: message,
    result: new Caesar().Encrypt(message, key)
);

PrintResult.Print(
    title: "Vigenere",
    color: ConsoleColor.DarkMagenta,
    message: message,
    result: new Vigenere().Encrypt(message, v_key)
);
