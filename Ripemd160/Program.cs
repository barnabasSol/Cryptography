using Ripemd160.Utils;

foreach (var item in InitVariables.Buffers)
{
    var buff_len = Convert.ToString(item, 2).ToString().Length;
    Console.WriteLine(buff_len);
}
var x = InitVariables.Buffers.Select(s => Convert.ToString(s, 2).ToString().Length).Sum();

Console.WriteLine(x);

Console.WriteLine("--------------------------------");