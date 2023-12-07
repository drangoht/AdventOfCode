using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7.Domain
{
    public class Card
    {
        public string CardName { get; set; } = string.Empty;
        public int Strength { get; set; } = 0;
        public override string ToString()
        {
            return $"Name:{CardName} Strength:{Strength}";
        }
    }
}
