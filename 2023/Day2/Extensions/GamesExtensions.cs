using Day2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2.Extensions
{
    public static class GamesExtensions
    {
        public static List<Game> GetImpossibleGames(this List<Game> games)
        {
            List<Game> impossibleGames = [];
            foreach (Cube cube in ChallengeRules.GetCubesRules())
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
            return impossibleGames;
        }
        public static int GetPower(this List<Game> games)
        {
            int resultPower = 0;
            foreach (Game game in games)
            {
                int maxRed = 1;
                int maxBlue = 1;
                int maxGreen = 1;
                foreach (Round round in game.Rounds)
                {

                    if (round.Cubes.Any(c => c.Color == "red") && round.Cubes.First(c => c.Color == "red").Count > maxRed)
                        maxRed = round.Cubes.First(c => c.Color == "red").Count;
                    if (round.Cubes.Any(c => c.Color == "blue") && round.Cubes.First(c => c.Color == "blue").Count > maxBlue)
                        maxBlue = round.Cubes.First(c => c.Color == "blue").Count;
                    if (round.Cubes.Any(c => c.Color == "green") && round.Cubes.First(c => c.Color == "green").Count > maxGreen)
                        maxGreen = round.Cubes.First(c => c.Color == "green").Count;
                }
                Console.WriteLine($"Id:{game.Id} r:{maxRed} b:{maxBlue} g:{maxGreen}");
                resultPower += maxRed * maxBlue * maxGreen;
            }
            return resultPower;
        }
    }
}