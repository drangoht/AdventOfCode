
using Day3.Domain;
using System.ComponentModel.DataAnnotations;

EngineSchematic engineSchematic = new EngineSchematic();
int y= 0;
foreach (string line in File.ReadLines(@"Inputs\Input.txt"))
{
    engineSchematic.AddPartsFromLine(line, y++);
}
var partsFound = engineSchematic.GetNumberPartsNearSymbolPart();
engineSchematic.DisplayParts(partsFound);
int result = partsFound.Sum(p => Convert.ToInt32(p.Value));
Console.WriteLine(result);
Console.ReadLine();