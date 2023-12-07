using Day7.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7.Extensions
{
    public static class HandExtensions
    {
        public static bool IsStrongest(this Hand hand,Hand comparedHand) 
        {
            for (var i = 0; i < hand.Cards.Count; i++)
            {
                if (hand.Cards[i].Strength> comparedHand.Cards[i].Strength)
                    return true;
                if (hand.Cards[i].Strength < comparedHand.Cards[i].Strength)
                    return false;
            }
            return false;
        }
    }
}
