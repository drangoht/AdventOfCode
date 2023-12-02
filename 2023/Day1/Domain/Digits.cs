namespace Day1.Domain
{
    public class Digits
    {
        public List<Digit> Numbers = [];

        public int MakeNumber()
        {
            int minNumber = Numbers.OrderBy(x => x.Position).First().Number;
            int maxNumber = Numbers.OrderByDescending(x => x.Position).First().Number;
            return Convert.ToInt32($"{minNumber}{maxNumber}");
        }
    }
}
