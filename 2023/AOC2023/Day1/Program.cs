// See https://aka.ms/new-console-template for more information
using Day1;
using Day1.Tools;

int resultCode = 0;
foreach (string line in File.ReadLines(@"Input.txt"))
{
    resultCode += Convert.ToInt32(Tools.GetNumberResultFromLine(line));
    Console.WriteLine($"line:{line}  result:{resultCode}");
}
Console.WriteLine($"Code:{resultCode}");
Console.ReadLine();

