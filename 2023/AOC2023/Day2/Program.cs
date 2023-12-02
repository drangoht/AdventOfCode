using Day2;
using Day2.Domain;


// Parse all games
List<Game> games = [];
foreach (string line in File.ReadLines(@"Inputs\Input.txt"))
{
    games.Add(Tools.ParseLineToGame(line));
}

// Define rules
List<Cube> cubeRules = new List<Cube>()
{
    new Cube("red", 12),
    new Cube("green", 13),
    new Cube("blue", 14)
};


// First part
// Get impossibles games
List<Game> impossibleGames = [];
foreach (Cube cube in cubeRules)
{
    // Search for impossible games
    impossibleGames.AddRange(
        games.Where(g => 
            g.Rounds.Any(r => 
                r.Cubes.Any(c => c.Color == cube.Color && c.Count > cube.Count)
            )
        )
    );
}
//Console.WriteLine($"Impossible games");
//Tools.Display(impossibleGames);

// Get possible Games
List<Game> possibleGames = games.Where(g => !impossibleGames.Any(ig => ig.Id == g.Id)).ToList();
//Console.WriteLine($"Possible games");
//Tools.Display(possibleGames);

// Calculate sum of the id of possible games
int result = possibleGames.Sum(g => g.Id);

Console.WriteLine($"result:{result}");


// Second Part
int resultPower = 0;
foreach (Game game in games)
{
    int maxRed = 1;
    int maxBlue = 1;
    int maxGreen = 1;
    foreach (Round round in game.Rounds)
    {

        if(round.Cubes.Any(c => c.Color == "red") && round.Cubes.First(c => c.Color == "red").Count>maxRed)
            maxRed = round.Cubes.First(c => c.Color == "red").Count ;
        if (round.Cubes.Any(c => c.Color == "blue") && round.Cubes.First(c => c.Color == "blue").Count > maxBlue)
            maxBlue = round.Cubes.First(c => c.Color == "blue").Count;
        if (round.Cubes.Any(c => c.Color == "green") && round.Cubes.First(c => c.Color == "green").Count > maxGreen)
            maxGreen = round.Cubes.First(c => c.Color == "green").Count;
    }
    Console.WriteLine($"Id:{game.Id} r:{maxRed} b:{maxBlue} g:{maxGreen}");
    resultPower += maxRed * maxBlue * maxGreen;
}
Console.WriteLine($"resultPower:{resultPower}");
// Get the max number by Round/Color and multiply then together

Console.ReadLine();