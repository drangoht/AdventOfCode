using Day14.Domain;

Map map = new Map();
map.ParseLineToPoints(File.ReadAllLines(@"Inputs\Input_test.txt").ToList());
var weight = map.CalculateSumOfRoundedRocks();

Console.WriteLine(weight);
Console.ReadLine();