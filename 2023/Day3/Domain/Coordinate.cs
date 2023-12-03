using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3.Domain
{
    public class Coordinate(int x, int y)
    {
        public int X { get; } = x;
        public int Y { get; } = y;
        public override string ToString()
        {
            return $"X:{X} Y:{Y}";
        }
    }
}
