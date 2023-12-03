using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3.Domain
{
    public class Part
    {
        public string Value { get; set; }
        public PartType PartType { get; set; }
        public List<Coordinate> Coordinates { get; set; } = [];
    }
}
