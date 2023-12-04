using Day4.Domain;

Game game = new Game();
int y = 0;
foreach (string line in File.ReadLines(@"Inputs\Input.txt"))
{
    game.AddCardFromLine(line);
}

// Part 1
//var result = game.Cards.Sum(c => c.CalculateWorthCount());
//Console.WriteLine(result);

// Part 2
game.GenerateDuplicates();
int result2 = game.CountAllInstances();
Console.WriteLine(result2);
Console.ReadLine();