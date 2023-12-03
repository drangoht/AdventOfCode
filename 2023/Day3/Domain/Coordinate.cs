using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3.Domain
{
    public class Coordinate
    {
        public Coordinate(int x,int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }
        public override string ToString()
        {
            return $"X:{X} Y:{Y}";
        }
    }
}
