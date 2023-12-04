using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4.Domain
{
    public class Game
    {
        public List<Card> Cards { get; set; } = [];
        public void AddCardFromLine(string line)
        {
            Card card = new Card();
            var arrCard = line.Split(':');
            var arrCardTitle = arrCard[0].Trim().Split(' ');
            card.Id = Convert.ToInt32(arrCardTitle[arrCardTitle.Length-1]);
            var arrNumbers = arrCard[1].Split('|');
            var arrWiningNumbers = arrNumbers[0].Trim().Split(' ');
            var arrMyNumbers = arrNumbers[1].Trim().Split(' ');

            foreach (var number in arrWiningNumbers)
            {
                if(number.Trim() != string.Empty)
                    card.WinningNumbers.Add(Convert.ToInt32(number.Trim()));
            }
            foreach (var number in arrMyNumbers)
            {
                if (number.Trim() != string.Empty)
                    card.MyNumbers.Add(Convert.ToInt32(number.Trim()));
            }
            Cards.Add(card);
        }

        public void GenerateDuplicates()
        {
            foreach (Card card in Cards)
            {
                int winningCount = card.WinningCount();
                for (int i = 0; i < card.CopyCount; i++)
                {
                    DuplicateForOneCard(card.Id, winningCount);
                }
            }
        }
        private void DuplicateForOneCard(int currentId,int duplicateCount)
        {
            int start = currentId + 1;
            int end = currentId + duplicateCount +1 ;
            for (int i = start; i < end; i++) 
            {
                if(Cards.Any(c => c.Id == i))
                    Cards.First(c => c.Id == i).CopyCount++;
            }
        }

        public int CountAllInstances()
        {
            return Cards.Sum(c => c.CopyCount);
        }
    }
}
