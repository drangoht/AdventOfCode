namespace Day1.Tools
{
    public static class Tools
    {
        public static int GetTotalDistance(List<int> colOne, List<int> colTwo)
        {
            var orderedColOne = colOne.OrderBy(n => n).ToList();
            var orderedColTwo = colTwo.OrderBy(n => n).ToList();
            int difference = 0;
            for(int rank=0;rank<orderedColOne.Count;rank++)
            {
                difference += Math.Abs(orderedColOne[rank] - orderedColTwo[rank]);
            }
            return difference;
        }
    }
}
