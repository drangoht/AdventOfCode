using Day2.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public static class Tools
    {
        public static Game ParseLineToGame(string line)
        {
            Game game = new Game();
            var arrGame = line.Split(':');
            game.Id= Convert.ToInt32(arrGame[0].Trim().Split(' ')[1]);

            
            var arrRound = arrGame[1].Split(';');
            foreach(var parseRound in arrRound)
            {
                Round round = new Round();
                var arrCubes = parseRound.Trim().Split(',');
                foreach (var parseCube in arrCubes)
                {
                    var detailsCube = parseCube.Trim().Split(' ');
                    Cube cube = new Cube(detailsCube[1], Convert.ToInt32(detailsCube[0]));
                    round.Cubes.Add(cube);
                }
                game.Rounds.Add(round);

            }
            
            return game;
        }

        public static void Display(List<Game> games) 
        {
            games.ForEach(game => { Console.WriteLine(game.Id); });
        }

    }
}
