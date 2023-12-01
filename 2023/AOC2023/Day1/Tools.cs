using Day1.Domain;
using Day1.Extensions;

namespace Day1.Tools
{
    public static class Tools
    {
        public static int GetNumberResultFromLine(string line)
        {
            Digits digits = new()
            {
                Numbers = []
            };
            digits.ParseLineNumberToDigits(line);
            digits.ParseLineStringNumberToDigits(line);
            return digits.MakeNumber();
        }
    }
}
