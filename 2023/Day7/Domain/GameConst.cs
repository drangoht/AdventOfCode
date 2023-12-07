using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7.Domain
{
    public static class GameConst
    {
        public static List<Card> CardTypes1
        {
            get
            {
                var cardTypes = new List<Card>();
                cardTypes.Add(new Card() { CardName = "2", Strength = 1 });
                cardTypes.Add(new Card() { CardName = "3", Strength = 2 });
                cardTypes.Add(new Card() { CardName = "4", Strength = 3 });
                cardTypes.Add(new Card() { CardName = "5", Strength = 4 });
                cardTypes.Add(new Card() { CardName = "6", Strength = 5 });
                cardTypes.Add(new Card() { CardName = "7", Strength = 6 });
                cardTypes.Add(new Card() { CardName = "8", Strength = 7 });
                cardTypes.Add(new Card() { CardName = "9", Strength = 8 });
                cardTypes.Add(new Card() { CardName = "T", Strength = 9 });
                cardTypes.Add(new Card() { CardName = "J", Strength = 10 });
                cardTypes.Add(new Card() { CardName = "Q", Strength = 11 });
                cardTypes.Add(new Card() { CardName = "K", Strength = 12 });
                cardTypes.Add(new Card() { CardName = "A", Strength = 13 });
                return cardTypes;
            }
        }
        public static List<Card> CardTypes2
        {
            get
            {
                var cardTypes = new List<Card>();
                cardTypes.Add(new Card() { CardName = "2", Strength = 1 });
                cardTypes.Add(new Card() { CardName = "3", Strength = 2 });
                cardTypes.Add(new Card() { CardName = "4", Strength = 3 });
                cardTypes.Add(new Card() { CardName = "5", Strength = 4 });
                cardTypes.Add(new Card() { CardName = "6", Strength = 5 });
                cardTypes.Add(new Card() { CardName = "7", Strength = 6 });
                cardTypes.Add(new Card() { CardName = "8", Strength = 7 });
                cardTypes.Add(new Card() { CardName = "9", Strength = 8 });
                cardTypes.Add(new Card() { CardName = "T", Strength = 9 });
                cardTypes.Add(new Card() { CardName = "J", Strength = 0 });
                cardTypes.Add(new Card() { CardName = "Q", Strength = 11 });
                cardTypes.Add(new Card() { CardName = "K", Strength = 12 });
                cardTypes.Add(new Card() { CardName = "A", Strength = 13 });
                return cardTypes;
            }
        }
    }
}
