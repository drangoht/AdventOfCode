using Day1.Domain;

namespace Day1.Extensions
{
    public static class DigitsExtensions
    {
        public static void ParseLineNumberToDigits(this Digits digits, string line)
        {
            int position = 0;
            foreach (char c in line)
            {
                if (Char.IsNumber(c))
                {
                    digits.Numbers.Add(new Digit()
                    {
                        Number = (int)(c - '0'),
                        Position = position,
                    });
                }
                position++;
            }
        }
        public static void AddPositionsForStringNumber(this Digits digits, string stringNumber, int number, string line)
        {
            var position = line.IndexOf(stringNumber);
            if (position == -1)
                return;

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
        }
        public static void ParseLineStringNumberToDigits(this Digits digits, string line)
        {
            digits.AddPositionsForStringNumber("zero", 0, line);
            digits.AddPositionsForStringNumber("one", 1, line);
            digits.AddPositionsForStringNumber("two", 2, line);
            digits.AddPositionsForStringNumber("three", 3, line);
            digits.AddPositionsForStringNumber("four", 4, line);
            digits.AddPositionsForStringNumber("five", 5, line);
            digits.AddPositionsForStringNumber("six", 6, line);
            digits.AddPositionsForStringNumber("seven", 7, line);
            digits.AddPositionsForStringNumber("eight", 8, line);
            digits.AddPositionsForStringNumber("nine", 9, line);
        }
    }
}
