using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Day1.Tools.Tools;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Day1.Tools
{
    public static class Tools
    {
        public static int GetNumberResultFromLine(string line)
        {
            Digits digits = new Digits();
            digits.Numbers = new List<Digit>();
            digits = ParseLineNumberToDigits(line, digits);
            digits = ParseLineStringNumberToDigits(line, digits);
            return digits.MakeNumber();
        }
        public static Digits ParseLineNumberToDigits(string line,Digits digits)
        {

            int position = 0;
            foreach(char c in line)
            {
                if(Char.IsNumber(c))
                {
                    digits.Numbers.Add(new Digit()
                    {
                        Number = (int)(c -'0'),
                        Position = position,
                    });
                }
                position++;
            }
            return digits;
        }
        public static Digits AddPositionsForStringNumber(string stringNumber,int number,string line,Digits digits)
        {
            var position = line.IndexOf(stringNumber);
            if (position == -1)
                return digits;

            digits.Numbers.Add(new Digit()
            {
                Number = number,
                Position = position
            });

            while ((position < line.Length) && position != -1)
            {
                position = line.IndexOf(stringNumber, position + 1);
                if (position >= 0)
                {
                    digits.Numbers.Add(new Digit()
                    {
                        Number = number,
                        Position = position
                    });
                }

            }
            return digits;
        }
        public static Digits ParseLineStringNumberToDigits(string line,Digits digits)
        {
            digits = AddPositionsForStringNumber("zero", 0, line, digits);
            digits = AddPositionsForStringNumber("one", 1, line, digits);
            digits = AddPositionsForStringNumber("two", 2, line, digits);
            digits = AddPositionsForStringNumber("three", 3, line, digits);
            digits = AddPositionsForStringNumber("four", 4, line, digits);
            digits = AddPositionsForStringNumber("five", 5, line, digits);
            digits = AddPositionsForStringNumber("six", 6, line, digits);
            digits = AddPositionsForStringNumber("seven", 7, line, digits);
            digits = AddPositionsForStringNumber("eight", 8, line, digits);
            digits = AddPositionsForStringNumber("nine", 9, line, digits);
            return digits;
        }
        
        public class Digit
        {
            public int Number { get; set; }
            public int Position { get; set; }
        }
        public class Digits
        {
            public List<Digit> Numbers = new List<Digit>();

            public int MakeNumber()
            {
                int minNumber = Numbers.OrderBy(x => x.Position).FirstOrDefault().Number;
                int maxNumber = Numbers.OrderByDescending(x => x.Position).FirstOrDefault().Number;
                Console.WriteLine($"{minNumber}{maxNumber}");
                return Convert.ToInt32($"{minNumber}{maxNumber}");
            }
        }
    }
}
