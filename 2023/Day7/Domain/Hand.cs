using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7.Domain
{
    public class Hand
    {
        public List<Card> Cards { get; set; } = [];
        public Int64 Bid { get; set; } = 0;
        public HandType HandType { get; set; }
        public Int64 Rank { get; set; } = 0;
        public override string ToString()
        {
            string displayString = $"Bid {Bid} Cards (";
            string displayCards = string.Empty;
            Cards.ForEach(card =>
            {
                displayCards += card.ToString() + " ";
            });
            return $"Bid {Bid} HandType: {HandType} Rank: {Rank} Cards: {displayCards}";
        }
        public void SetHandType()
        {
            var cardsCount = Cards
                .GroupBy(c => c.CardName)
                .Select(x => new
                {
                    Card = x.Key,
                    Nb = x.Count()
                })
                .ToList();
            // High Card
            if (cardsCount.Max(c => c.Nb) == 1)
            {
                HandType = HandType.HighCard;
                return;
            }
            // Pair(s)
            if (cardsCount.Max(c => c.Nb) == 2)
            {
                // Count pairs
                var pairsCount = cardsCount.Where(c => c.Nb == 2).Count();
                if (pairsCount == 1)
                    HandType = HandType.OnePair;
                else
                    HandType = HandType.TwoPairs;
                return;
            }
            // ThreeOfAKind
            if (cardsCount.Max(c => c.Nb) == 3)
            {
                // Full ?
                if (cardsCount.Any(c => c.Nb == 2))
                    HandType = HandType.FullHouse;
                else
                    HandType = HandType.ThreeOfAKind;
                return;
            }
            // FourOfAKind
            if (cardsCount.Max(c => c.Nb) == 4)
            {
                HandType = HandType.FourOfAKind;
                return;
            }
            //FiveOfAKind
            if (cardsCount.Max(c => c.Nb) == 5)
            {
                HandType = HandType.FiveOfAKind;
                return;
            }
        }
        public void SetHandTypeWithJoker()
        {
            var cardsCount = Cards
                .GroupBy(c => c.CardName)
                .Select(x => new
                {
                    CardName = x.Key,
                    Nb = x.Count()
                })
                .ToList();
            // High Card
            var cardCountsWithoutJ = cardsCount.Where(c => c.CardName != "J");
            if(!cardCountsWithoutJ.Any())
            {
                HandType = HandType.FiveOfAKind;
                return;
            }
            if (cardCountsWithoutJ.Max(c => c.Nb) == 1)
            {
                // ContainsJoker ?
                if(cardsCount.Any(c => c.CardName=="J"))
                {
                    HandType = GetHandTypeByCardsCount(cardsCount.First(c => c.CardName == "J").Nb + 1);
                    return;
                }
                HandType = HandType.HighCard;
                return;
            }
            // Pair(s)
            if (cardCountsWithoutJ.Max(c => c.Nb) == 2)
            {
                // Count pairs
                var pairsCount = cardCountsWithoutJ.Where(c => c.Nb == 2).Count();
                if (pairsCount == 1)
                {
                    if (cardsCount.Any(c => c.CardName == "J"))
                    {
                        HandType = GetHandTypeByCardsCount(cardsCount.First(c => c.CardName == "J").Nb + 2);
                        return;
                    }
                    HandType = HandType.OnePair;
                }
                else
                {
                    if (cardsCount.Any(c => c.CardName == "J"))
                    {
                        HandType = HandType.FullHouse;
                        return;
                    }
                    HandType = HandType.TwoPairs;
                }
                return;
            }
            // ThreeOfAKind
            if (cardCountsWithoutJ.Max(c => c.Nb) == 3)
            {
                // Full ?
                if (cardCountsWithoutJ.Any(c => c.Nb == 2))
                {
                    HandType = HandType.FullHouse;
                }
                else
                {
                    if (cardsCount.Any(c => c.CardName == "J"))
                    {
                        HandType = GetHandTypeByCardsCount(cardsCount.First(c => c.CardName == "J").Nb + 3);
                        return;
                    }
                    HandType = HandType.ThreeOfAKind;
                }
                return;
            }
            // FourOfAKind
            if (cardCountsWithoutJ.Max(c => c.Nb) == 4)
            {
                if (cardsCount.Any(c => c.CardName == "J"))
                {
                    HandType = HandType.FiveOfAKind;
                    return;
                }
                HandType = HandType.FourOfAKind;
                return;
            }
            //FiveOfAKind
            if (cardCountsWithoutJ.Max(c => c.Nb) == 5)
            {
                HandType = HandType.FiveOfAKind;
                return;
            }
        }
        private HandType GetHandTypeByCardsCount(int cardsCount)
        {
            switch (cardsCount)
            {
                case 2: return HandType.OnePair;
                case 3: return HandType.ThreeOfAKind;
                case 4: return HandType.FourOfAKind;
                case 5: return HandType.FiveOfAKind;
                default: return HandType.OnePair;
            }
        }
    }
}