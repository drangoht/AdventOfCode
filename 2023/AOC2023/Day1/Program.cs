using Day1.Tools;

int resultCode = 0;
foreach (string line in File.ReadLines(@"Inputs\Input.txt"))
{
    resultCode += Convert.ToInt32(Tools.GetNumberResultFromLine(line));
}
Console.WriteLine($"Code:{resultCode}");
Console.ReadLine();

