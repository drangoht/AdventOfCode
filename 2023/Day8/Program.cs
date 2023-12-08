using Day8.Domain;

Map map = new Map();
map.PartNumber = 1;
map.ParseLinesToMap(File.ReadLines(@"Inputs\Input.txt").ToList());
//map.Display();
var result1 = map.GetStepsNumberPart1();
Console.WriteLine($"Steps number: {result1}");

var result2 = map.GetStepsNumberPart2();
Console.WriteLine($"Steps number: {result2}");
Console.ReadLine();