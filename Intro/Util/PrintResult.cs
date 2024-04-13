namespace Intro.Util;

public static class PrintResult
{
    public static void Print(ConsoleColor color, string message, string result, string title)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("========================================");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Encryption: {title}");
        Console.ForegroundColor = color;
        Console.WriteLine($"Message: {message}");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Result: {result}");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("========================================");
        Console.ResetColor();
    }
}
