using Day7.Domain;

Game game = new Game();
game.PartNumber = 1;
game.FillHandWithLines(File.ReadLines(@"Inputs\Input.txt").ToList());
//game.DisplayHands();
//game.DisplayStringHands();
var result1 = game.CalculateTotalWinnings();
Console.WriteLine($"Result1:{result1}");

game = new Game();
game.PartNumber = 2;
game.FillHandWithLines(File.ReadLines(@"Inputs\Input.txt").ToList());
//game.DisplayHands();
//game.DisplayStringHands();
var result2 = game.CalculateTotalWinnings();
Console.WriteLine($"Result2:{result2}");
Console.ReadLine();