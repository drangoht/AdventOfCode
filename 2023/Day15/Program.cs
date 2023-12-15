
using Day15.Domain;

var lines = File.ReadAllLines(@"Inputs\Input.txt");
Library library = new Library();
// Part1
Int64 result = 0;
Int64 tot = 0;
var stringToHash = lines[0].Split(",");
foreach (var seq in stringToHash)
{
    result = library.HashString(seq);
    tot += result;
}
Console.WriteLine(tot);

// Part2
library.HashMap = lines[0];
library.OrderBoxes();
result = library.CalculateFocusingPower();
Console.WriteLine(result);
Console.ReadLine();