using Day11.Domain;

// FAIL! I'LL SEE THAT DAY LATER
GalaxiesImage gImage = new GalaxiesImage();
gImage.ParseLineToPoints(File.ReadAllLines(@"Inputs\Input.txt").ToList());
Console.WriteLine(gImage.CalculateAllDistancesBetweenGalaxies());
Console.ReadLine();