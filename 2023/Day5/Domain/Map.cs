using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5.Domain
{
    public class Map
    {
        public List<Range> Ranges { get; set; } = [];
        public MapType MapType { get; set; }

        public Int64 GetMatchingNumber(Int64 srcNumber)
        {
            Range? matchingRange = Ranges.FirstOrDefault(r => r.Min<=srcNumber && r.Max>=srcNumber);
            if (matchingRange is null)
                return srcNumber;
            return (srcNumber-matchingRange.Min) + matchingRange.MinDest;
        }
    }
}
