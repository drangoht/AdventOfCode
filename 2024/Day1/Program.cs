using Day1.Tools;

int difference = 0;
List<int> colOne = new List<int>();
List<int> colTwo = new List<int>();
foreach (string line in File.ReadLines(@"Inputs\Input.txt"))
{
    colOne.Add(Int32.Parse(line.Split("  ")[0]));
    colTwo.Add(Int32.Parse(line.Split("  ")[1]));

    difference = Tools.GetTotalDistance(colOne, colTwo);
}
Console.WriteLine($"Difference:{difference}");
Console.ReadLine();

