using Day4.Domain;

Game game = new Game();
int y = 0;
foreach (string line in File.ReadLines(@"Inputs\Input.txt"))
{
    game.AddCardFromLine(line);
}

var result = game.Cards.Sum(c => c.CalculateWorthCount());
Console.WriteLine(result);
Console.ReadLine();