
using Day3.Domain;
using System.ComponentModel.DataAnnotations;

EngineSchematic engineSchematic = new EngineSchematic();
int y= 0;
foreach (string line in File.ReadLines(@"Inputs\Input.txt"))
{
    engineSchematic.AddPartsFromLine(line, y++);
}
// Part 1
var partsFound = engineSchematic.GetNumberPartsNearSymbolPart();
int result = partsFound.Sum(p => Convert.ToInt32(p.Value));
Console.WriteLine(result);

// Part 2
result = engineSchematic.GetMultiplyResultFromGearNeighbours();
Console.WriteLine(result);
Console.ReadLine();