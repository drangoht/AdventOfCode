using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11.Domain
{
    public class Point
    {
        public char Value { get; set; }
        public int Id { get; set; } = -1;
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public List<Point> ConnectedPoints { get; set; } = [];
        public bool Origin { get; set; } = false;
        public override string ToString()
        {
            var display = $"Id:{Id} {X},{Y}";
            //{Origin}";
            //foreach(var point in ConnectedPoints)
            //{
            //    display += $" cp: {point.X},{point.Y}" ;
            //}
            return display;
        }
        public override bool Equals(object? obj)
        {
            Point? point = (Point?)obj;
            return (X==point?.X && Y==point?.Y);
        }
    }
}
