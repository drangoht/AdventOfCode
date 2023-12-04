using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4.Domain
{
    public class Card
    {
        public List<int> WinningNumbers { get; set; } = [];
        public List<int> MyNumbers { get; set; } = [];
        public int Id { get; set; }

        public int CopyCount { get; set; } = 1;
        private List<int> GetWinningNumbers()
        {
            return MyNumbers.Where(n => WinningNumbers.Contains(n)).ToList();
        }
        public int CalculateWorthCount()
        {
            double result = 0;
            var winningNumbers = GetWinningNumbers();
            if(winningNumbers.Count > 0) 
            {
                // 2expCount (2^0 =1, 2^1 = 2, 2^2=4, 2^3=8, ...)
                result = Math.Pow((double)2,(double)(winningNumbers.Count - 1));

            }
            return Convert.ToInt32(result);
        }
        public int WinningCount() => GetWinningNumbers().Count();

    }
}
