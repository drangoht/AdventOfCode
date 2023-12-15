var lines = File.ReadAllLines(@"Inputs\Input.txt");
var result = 0;
var tot = 0;
foreach (var seq in lines[0].Split(","))
{
    result = 0;
    foreach (var car in seq)
    {
        var asc = (int)car;
        result = ((result + asc) * 17) % 256;
    }
    tot += result;
}
Console.WriteLine(tot);
Console.ReadLine();