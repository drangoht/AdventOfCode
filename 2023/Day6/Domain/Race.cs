using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6.Domain
{
    public class Race
    {
        public Int64 RaceTime { get; set; }
        public Int64 DistanceRecord { get; set; }

        public override string ToString()
        {
            return $"RaceTime:{RaceTime} DistanceRecord:{DistanceRecord}";
        }
        public List<int> CalculateWaysNumber()
        {
            List<int> ways = [];
            for (int speed = 0; speed < RaceTime; speed++) 
            {
                if((((RaceTime-speed)*speed) - DistanceRecord)>0)
                {
                    ways.Add(speed);
                }
            }
            return ways;
        }
    }
}
