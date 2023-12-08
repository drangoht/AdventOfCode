using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    public static class Tools
    {
        private static long GreatestCommonDivisor(long a, long b)
        {
            while (b != 0)
            {
                long tmp = b;
                b = a % b;
                a = tmp;
            }

            return a;
        }

        public static long LowestCommonMultiplier(long a, long b)
        {
            return a / GreatestCommonDivisor(a, b) * b;
        }
    }
}
