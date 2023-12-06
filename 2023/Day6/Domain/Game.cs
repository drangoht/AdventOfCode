using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day6.Domain
{
    public class Game
    {
        List<Race> races = [];
        public void ParseLinesToRaces(List<string> lines)
        {
            string[] times = Regex.Split(lines[0], @"\s+");
            string[] distances = Regex.Split(lines[1], @"\s+");
            for(int i = 1; i < times.Length; i++)
            {
                Race race = new Race();
                race.RaceTime = Convert.ToInt64(times[i]);
                race.DistanceRecord = Convert.ToInt64(distances[i]);
                races.Add(race);
            }
        }

        public void DisplayRaces()
        {
            foreach (Race race in races)
            {
                Console.WriteLine(race.ToString());
            }
        }
        public int CalculateWaysResult()
        {
            int result = 1;
            foreach(Race race in races)
            {
                result*=race.CalculateWaysNumber().Count;
            }
            return result;
        }
    }
}
