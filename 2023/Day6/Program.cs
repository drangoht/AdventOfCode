using Day6.Domain;

Game game = new Game();
game.ParseLinesToRaces(File.ReadLines(@"Inputs\Input_part2.txt").ToList());

game.DisplayRaces();


Console.WriteLine(game.CalculateWaysResult());
Console.ReadLine();