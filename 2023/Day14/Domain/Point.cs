using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14.Domain
{
    public class Point
    {
        public char Value { get; set; }
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public override string ToString()
        {
            var display = $"{Value} {X},{Y}";
            return display;
        }
        public override bool Equals(object? obj)
        {
            Point? point = (Point?)obj;
            return (X==point?.X && Y==point?.Y);
        }
    }
}
