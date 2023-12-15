using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day15.Domain
{
    public class Lens
    {
        public Lens(string label,int focalLength)
        {
            Label = label;
            this.FocalLength = focalLength;
        }

        public string Label { get; set; }
        public int FocalLength { get; set; }
    }
}
