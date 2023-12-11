
using Day10.Domain;

// FAIL! I'LL SEE THAT DAY LATER
SurfacePipes surfacePipes = new SurfacePipes();
surfacePipes.ParseLineToPoints(File.ReadLines(@"Inputs\Input.txt").ToList());

//surfacePipes.Display();
Console.WriteLine("--------------------------------------------------");
var result = surfacePipes.FindLongestPath();

Console.WriteLine(result);
Console.ReadLine();