using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2.Domain
{
    public class Game
    {
        public int Id { get; set; }
        public List<Round> Rounds { get; set; } = [];
    }
}
