using Day11.Domain;

GalaxiesImage gImage = new GalaxiesImage();
gImage.ParseLineToPoints(File.ReadAllLines(@"Inputs\Input.txt").ToList());
// Part 1
//gImage.EmptyMultiplier = 2;
//Console.WriteLine(gImage.CalculateAllDistancesBetweenGalaxies());

// Part 2
gImage.EmptyMultiplier = 1000000;
Console.WriteLine(gImage.CalculateAllDistancesBetweenGalaxies());

Console.ReadLine();