using Day2.Tools;


int safeReports = 0;
foreach (string line in File.ReadLines(@"Inputs\Input.txt"))
{
    var reports = line.Split(' ').Select(n => Int32.Parse(n)).ToList();
    if( Tools.IsSafe(reports))
        safeReports++;
}
Console.WriteLine($"Difference:{safeReports}");
Console.ReadLine();

