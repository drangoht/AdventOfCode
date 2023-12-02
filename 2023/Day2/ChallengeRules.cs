using Day2.Domain;

namespace Day2
{
    public static class ChallengeRules
    {
        public static List<Cube> GetCubesRules() =>
            new List<Cube>()
            {
                new Cube("red", 12),
                new Cube("green", 13),
                new Cube("blue", 14)
            };
    }
}
