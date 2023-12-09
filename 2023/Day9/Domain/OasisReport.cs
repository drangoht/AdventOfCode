using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9.Domain
{
    public class OasisReport
    {
        public List<int> ParseLinesToSeriesAndCalcultateNextNumber(List<string> lines)
        {
            List<int> results = new List<int>();
            List<int> serie = new List<int>();
            foreach (string line in lines)
            {
                serie = new List<int>();
                var arrNumber = line.Split(' ');
                foreach (var number in arrNumber)
                {
                    serie.Add(int.Parse(number));
                }
                results.Add(CalculateNextNumber(serie));
            }
            return results;
        }

        public List<int> ParseLinesToSeriesAndCalcultateFirstNumber(List<string> lines)
        {
            List<int> results = new List<int>();
            List<int> serie = new List<int>();
            foreach (string line in lines)
            {
                serie = new List<int>();
                var arrNumber = line.Split(' ');
                foreach (var number in arrNumber)
                {
                    serie.Add(int.Parse(number));
                }
                serie.Reverse();
                results.Add(CalculateNextNumber(serie));
            }
            return results;
        }
        private int CalculateNextNumber(List<int> numbers)
        {
            if (numbers.All(x => x == 0))
                return 0;
            if(numbers.Count == 1) 
                return numbers[0];
            if (numbers.Count == 0) 
                return 0;

            List<int> newNumbersLine = new List<int>();
            for (int i = 0; i < numbers.Count-1; i++)
            {
                newNumbersLine.Add(numbers[i+1] - numbers[i]);
            }
            int nextNumber = CalculateNextNumber(newNumbersLine);
            return numbers.Last() + nextNumber;
        }
    }
}
