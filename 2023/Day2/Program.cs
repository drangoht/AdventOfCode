using Day2;
using Day2.Domain;
using Day2.Extensions;


// Parse all games
List<Game> games = [];
foreach (string line in File.ReadLines(@"Inputs\Input.txt"))
{
    games.Add(Tools.ParseLineToGame(line));
}

// First part
List<Game> impossibleGames = games.GetImpossibleGames();
List<Game> possibleGames = games.Where(g => !impossibleGames.Any(ig => ig.Id == g.Id)).ToList();

int result = possibleGames.Sum(g => g.Id);
Console.WriteLine($"result:{result}");


// Second Part
int power = games.GetPower();
Console.WriteLine($"resultPower:{power}");

Console.ReadLine();