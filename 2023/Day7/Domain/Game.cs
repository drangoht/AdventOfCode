using Day7.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7.Domain
{
    public class Game
    {
        List<Hand> Hands { get; set; } = [];
        public List<string> stringHands { get; set; } = [];
        public int PartNumber { get; set; } = 1;
        public void FillHandWithLines(List<string> lines)
        {
            foreach (var line in lines)
            {
                stringHands.Add(line);
                var hand = new Hand();
                hand.Cards = ConvertStringToCards(line.Split(' ')[0]);
                hand.Bid = Convert.ToInt64(line.Split(' ')[1]);
                if (PartNumber == 1)
                    hand.SetHandType();
                else
                    hand.SetHandTypeWithJoker();

                Hands.Add(hand);

            }
            SetHandsRank();
        }
        private List<Card> ConvertStringToCards(string cardString)
        {
            var cards = new List<Card>();
            foreach (char card in cardString)
            {
                if(PartNumber==1)
                    cards.Add(GameConst.CardTypes1.First(c => c.CardName == card.ToString()));
                else
                    cards.Add(GameConst.CardTypes2.First(c => c.CardName == card.ToString()));
            }
            return cards;
        }

        public void DisplayHands()
        {
            Hands.ForEach(h =>
            {
                Console.WriteLine($"Hand: {h.ToString()}");
            });
            
        }
        public void DisplayStringHands()
        {
            for (int i = 0; i < Hands.Count; i++)
            {
                Console.WriteLine($"{stringHands[i]} {Hands[i].HandType}");
            }

        }
        private void SetHandsRank()
        {
            var sorteredHands = Hands.OrderByDescending(h => h.HandType).ToList();
            for (int i = 0; i < sorteredHands.Count; i++)
            {
                var handToCompare = sorteredHands[i];
                var rank = 1;
                for (int j = 0;j< sorteredHands.Count;j++)
                {
                    if (i != j)
                    {
                        var currentHand = sorteredHands[j];
                        if (currentHand.HandType == handToCompare.HandType)
                        {
                            if (handToCompare.IsStrongest(currentHand))
                                rank++;
                        }
                        if ((int)handToCompare.HandType > (int)currentHand.HandType)
                            rank++;
                    }
                }
                handToCompare.Rank = rank;
            }
        }
        public Int64 CalculateTotalWinnings()
        {
            Int64 result = 0;
            foreach (var hand in Hands)
            {
                result += hand.Bid * hand.Rank;
            }
            return result;
        }
    }
}
